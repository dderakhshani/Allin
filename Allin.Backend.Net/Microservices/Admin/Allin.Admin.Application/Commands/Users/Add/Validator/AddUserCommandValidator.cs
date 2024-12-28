using FluentValidation;


namespace Allin.Admin.Application.Commands
{
    public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Please specify the Username");//Errors must be obtain from Language Resources
            RuleFor(x => x.Password).NotNull().WithMessage("Please specify the Password");//Errors must be obtain from Language Resources

            RuleForEach(x => x.Roles).SetValidator(new AddUserCommandRolesValidator());
        }
    }

    public class AddUserCommandRolesValidator : AbstractValidator<AddUserCommandRoles>
    {
        public AddUserCommandRolesValidator()
        {

        }
    }
}