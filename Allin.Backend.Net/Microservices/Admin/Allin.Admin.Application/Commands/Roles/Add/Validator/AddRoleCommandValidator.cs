using Allin.CommonLibrary.Localizations;
using FluentValidation;

namespace Allin.Admin.Application.Commands
{
    public sealed class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidator(ILocalizator localizator)
        {
            RuleFor(x => x.Title).NotNull().WithMessage(localizator["TitleIsRequired"]);
            RuleFor(x => x.UniqueName).NotNull().WithMessage(localizator["NameIsRequired"]);
        }
    }
}
