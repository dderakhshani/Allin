using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditPersonCommand : IRequest<bool>, IMapFrom<Person, EditPersonCommand>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public IList<string> Phones { get; set; }
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
}
