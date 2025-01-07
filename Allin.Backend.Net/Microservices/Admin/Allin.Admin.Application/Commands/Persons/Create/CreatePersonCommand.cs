using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreatePersonCommand : IRequest<bool>, IMapFrom<Person, CreatePersonCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public IList<PhoneArg> Mobiles { get; set; }
        public bool? IsLegal { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string SignatureImageUrl { get; set; }
        public DateOnly? BirthDate { get; set; }
        public GenderEnums GenderEnum { get; set; }
        public MaritalEnums? MaritalEnum { get; set; }
        public IEnumerable<ExtendedFieldArg> ExtendedFieldValues { get; set; }
        public IEnumerable<AddressArg> PersonAddresses { get; set; }

    }

    public class ExtendedFieldArg : IMapFrom<TableExtendedFieldValue, ExtendedFieldArg>
    {
        public long TableExtendedFieldId { get; set; }
        public string Value { get; set; }
        public string? ValueFieldItemId { get; set; }
    }

    public class AddressArg : IMapFrom<PersonAddress, AddressArg>
    {
        public long TypeBaseId { get; set; }
        public long CityBaseId { get; set; }
        public string Address { get; set; }
    }

    public class PhoneArg
    {
        public PhoneTypeEnum Type { get; set; }
        public string PhoneNumber { get; set; }

        public enum PhoneTypeEnum
        {
            HomePhone = 1,

            OfficePhone = 2,
            Mobile = 3,
            Fax = 4
        }
    }
}