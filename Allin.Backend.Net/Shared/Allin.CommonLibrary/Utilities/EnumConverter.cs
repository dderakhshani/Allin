using Allin.CommonLibrary.Localizations;

namespace Allin.Common.Utilities
{
    public interface IEnumConverter
    {
        string GetEnumDescription(Enum value);
    }

    public class EnumConverter : IEnumConverter
    {
        private ILocalizator _localizator;

        public EnumConverter(ILocalizator localizator)
        {
            _localizator = localizator;
        }
        //public static IList<EnumDto> GetKeyValueList<TEnum>() where TEnum : Enum
        //{
        //    var items = (TEnum[])Enum.GetValues(typeof(TEnum));
        //    var list = new List<EnumDto>();
        //    foreach (var item in items)
        //    {
        //        var enumMember = item.GetType().GetMember(item.ToString()).FirstOrDefault();
        //        var description = enumMember.GetCustomAttribute<DescriptionAttribute>().Description;
        //        int value = (int)Enum.Parse(typeof(TEnum), enumMember.Name);

        //        list.Add(new EnumDto()
        //        {

        //            Name = enumMember.Name,
        //            Title = description,
        //            Value = value,
        //            Type = typeof(TEnum).Name
        //        });
        //    }

        //    return list;
        //}

        public string GetEnumDescription(Enum value)
        {
            if (value == null)
                return null;
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());

            var title = _localizator[$"{enumType}.{field}"];
            return title;
            //var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;

        }
    }
}
