using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class DepartmentModel : BaseHierarchyModel, IMapFrom<Department, DepartmentModel>
    {
        //PrantId shouldn't be here(It is in BaseHierarchyModel) in order to ToTreeModel works fine
        public string Code { get; set; }
        public string Title { get; set; }
        public long BranchId { get; set; }
    }
}
