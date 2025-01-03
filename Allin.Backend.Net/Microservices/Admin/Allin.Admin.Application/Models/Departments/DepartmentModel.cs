using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class DepartmentModel : AdminBaseModel, IMapFrom<Department, DepartmentModel>
    {
        public long? ParentId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public long BranchId { get; set; }
    }
}
