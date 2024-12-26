namespace Allin.Common.Validations
{
    public interface IBusinessRuleValidator<T> //where T : IRequest
    {
        Task<BusinessRuleResult> ValidateAsync(T command);
    }

    public class BusinessRuleResult
    {
        private BusinessRuleResult()
        {

        }
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public static BusinessRuleResult Valid()
        {
            return new BusinessRuleResult
            {
                IsValid = true,
                Message = ""
            };
        }

        public static BusinessRuleResult InValid(string message)
        {
            return new BusinessRuleResult
            {
                IsValid = false,
                Message = message
            };
        }

        public static BusinessRuleResult Create(bool isValid, string message)
        {
            return new BusinessRuleResult
            {
                IsValid = isValid,
                Message = isValid ? string.Empty : message
            };
        }
    }
}
