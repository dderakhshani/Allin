using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Allin.Common.Validations
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IEnumerable<IBusinessRuleValidator<TRequest>> _businessRules;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IEnumerable<IBusinessRuleValidator<TRequest>> businessRules)
        {
            _validators = validators;
            _businessRules = businessRules;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationFailure(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage))
                .ToList();

            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            //-------------------Validate Business Rules----------------------------
            var businessResults = new List<BusinessRuleResult>();
            foreach (var br in _businessRules)
            {
                businessResults.Add(await br.ValidateAsync(request));
            }


            var businessErrors = businessResults
                .Where(validationResult => !validationResult.IsValid)
                .Select(validationFailure => validationFailure.Message)
                .ToList();

            if (businessErrors.Any())
            {
                throw new BuesinessRuleException(businessErrors);
            }

            var response = await next();

            return response;
        }
    }
}
