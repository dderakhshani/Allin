using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Converters;
using Allin.Common.Utilities.Mappings;
using System.Text.Json.Serialization;

namespace Allin.Admin.Application.Models
{
    public class BriefPersonModel : AdminBaseModel, IMapFrom<Person, BriefPersonModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }

        [JsonConverter(typeof(EnumToLocalizedStringConverter))]
        public GenderEnums GenderEnum { get; set; }

        [JsonConverter(typeof(EnumToLocalizedStringConverter))]
        public MaritalEnums MaritalEnum { get; set; }
    }
}
