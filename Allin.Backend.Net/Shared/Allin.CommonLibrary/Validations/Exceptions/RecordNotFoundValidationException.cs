using Allin.CommonLibrary.Localizations;
using FluentValidation;

namespace Allin.Common.Validations
{
    public class RecordNotFoundValidationException : ValidationException
    {
        public RecordNotFoundValidationException(ILocalizator localizator) : base(localizator["RecordNotFound"])
        {
        }
    }
}
