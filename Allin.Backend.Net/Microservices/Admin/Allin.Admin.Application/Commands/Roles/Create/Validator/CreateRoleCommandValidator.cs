using Allin.CommonLibrary.Localizations;
using FluentValidation;

namespace Allin.Admin.Application.Commands
{
    public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator(ILocalizator localizator)
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage(localizator["TitleIsRequired"]);
            RuleFor(x => x.UniqueName).NotEmpty().NotNull().WithMessage(localizator["NameIsRequired"]);
        }
    }
}
