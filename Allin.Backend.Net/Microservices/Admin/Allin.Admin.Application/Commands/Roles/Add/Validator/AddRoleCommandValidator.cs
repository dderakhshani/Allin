using FluentValidation;

namespace Allin.Admin.Application.Commands.Roles.Add.Validator
{
    public sealed class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Please specify the Username");//Errors must be obtain from Language Resources
        }
    }
}
