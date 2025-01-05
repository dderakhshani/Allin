using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class PersonModel : AdminBaseModel, IMapFrom<Person, PersonModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public IList<string> Mobiles { get; set; }
        public IList<int> Cities { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string SignatureImageUrl { get; set; }
        public DateOnly? BirthDate { get; set; }
        public GenderEnums GenderEnum { get; set; }
        public MaritalEnums? MaritalEnum { get; set; }
        public IEnumerable<TableExtendedFieldValueModel> ExtendedFieldValues { get; set; }
    }
}
