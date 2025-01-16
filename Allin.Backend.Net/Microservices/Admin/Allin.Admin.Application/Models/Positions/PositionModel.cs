using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using Allin.Common.Models;

namespace Allin.Admin.Application.Models
{
    public class PositionModel : BaseHierarchyModel, IMapFrom<Position, PositionModel>
    {
        public long? ParentId { get; set; }
        public string Title { get; set; }

    }
}
