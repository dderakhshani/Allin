using Microsoft.Extensions.Localization;

namespace Allin.CommonLibrary.Localizations
{
    internal class Localizator : ILocalizator
    {
        internal IStringLocalizer Localizer { get; set; }

        public LocalizedString Get(string key)
        {
            return Localizer[key];
        }

        public string GetValue(string key)
        {
            return Localizer[key].Value;
        }

        public string this[string key]
        {
            get
            {
                return GetValue(key);
            }
        }
    }
}
