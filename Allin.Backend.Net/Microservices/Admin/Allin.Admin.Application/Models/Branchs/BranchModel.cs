using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class BranchModel : AdminBaseModel, IMapFrom<Branch, BranchModel>
    {
        public string Title { get; set; }
        public string UniqueName { get; set; }
        //public virtual ICollection<DepartmentModel> Departments { get; set; }
    }
}
