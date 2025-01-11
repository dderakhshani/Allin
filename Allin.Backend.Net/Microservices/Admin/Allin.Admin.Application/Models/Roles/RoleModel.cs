using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class RoleModel : AdminBaseModel, IMapFrom<Role, RoleModel>
    {
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Description { get; set; }
        // public IList<string> Phones { get; set; }
        public IEnumerable<PermissionModel> Permissions { get; set; }
        // public virtual ICollection<PermissionModel> UserRoles { get; set; } = new List<UserRole>();
    }
}
