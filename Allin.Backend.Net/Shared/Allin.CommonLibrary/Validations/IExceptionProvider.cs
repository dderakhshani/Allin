namespace Allin.Common.Validations
{
    public interface IExceptionProvider
    {
        RecordNotFoundValidationException RecordNotFoundValidationException();
        DuplicatedRecordValidationException DuplicatedRecordValidationException();
    }
}
