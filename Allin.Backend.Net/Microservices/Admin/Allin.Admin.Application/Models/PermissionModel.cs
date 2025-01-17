using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class PermissionModel : BaseHierarchyModel, IMapFrom<Permission, PermissionModel>
    {
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string SubSystem { get; set; }
    }
}
