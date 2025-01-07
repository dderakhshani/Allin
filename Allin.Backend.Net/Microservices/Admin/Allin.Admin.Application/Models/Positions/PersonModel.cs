using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class PositionModel : AdminBaseModel, IMapFrom<Position, PositionModel>
    {
        public long? ParentId { get; set; }
        public string LevelCode { get; set; }
        public string Title { get; set; }

        public virtual PositionModel Parent { get; set; }
    }
}
