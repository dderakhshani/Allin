using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class PersonAddressModel : AdminBaseModel, IMapFrom<PersonAddress, PersonAddressModel>
    {
        public long PersonId { get; set; }
        public long TypeBaseId { get; set; }
        public long CityBaseId { get; set; }
        public string Address { get; set; }

    }
}
