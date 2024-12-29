using Microsoft.Extensions.Localization;

namespace Allin.CommonLibrary.Localizations
{
    public interface ILocalizator
    {
        LocalizedString Get(string key);
        string GetValue(string key);
        string this[string key] { get; }
    }
}