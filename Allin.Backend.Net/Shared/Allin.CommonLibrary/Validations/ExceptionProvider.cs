using Allin.CommonLibrary.Localizations;

namespace Allin.Common.Validations
{
    public class ExceptionProvider : IExceptionProvider
    {
        private readonly ILocalizator _localizator;
        public ExceptionProvider(ILocalizator localizator)
        {
            _localizator = localizator;
        }

        public RecordNotFoundValidationException RecordNotFoundValidationException() => new(_localizator);

        public DuplicatedRecordValidationException DuplicatedRecordValidationException() => new(_localizator);
    }
}
