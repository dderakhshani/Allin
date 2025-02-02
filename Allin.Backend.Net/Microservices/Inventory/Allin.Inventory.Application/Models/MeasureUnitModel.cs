using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class MeasureUnitModel : BaseHierarchyModel, IMapFrom<MeasureUnit, MeasureUnitModel>
    {
        public string? Title { get; set; }
    }
}
