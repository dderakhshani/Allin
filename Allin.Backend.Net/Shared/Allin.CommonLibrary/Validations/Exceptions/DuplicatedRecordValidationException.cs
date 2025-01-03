using Allin.CommonLibrary.Localizations;
using FluentValidation;

namespace Allin.Common.Validations
{
    public class DuplicatedRecordValidationException : ValidationException
    {
        public DuplicatedRecordValidationException(ILocalizator localizator) : base(localizator["DuplicatedRecord"])
        {
        }
    }
}
