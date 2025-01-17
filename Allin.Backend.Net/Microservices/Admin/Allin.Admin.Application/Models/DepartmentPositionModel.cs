using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class DepartmentPositionModel : AdminBaseModel, IMapFrom<DepartmentPosition, DepartmentPositionModel>
    {
        public long PositionId { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentModel Department { get; set; }
        public virtual PositionModel Position { get; set; }
    }
}
