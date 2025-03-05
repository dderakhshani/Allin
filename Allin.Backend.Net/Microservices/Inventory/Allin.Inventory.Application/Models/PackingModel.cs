using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class PackingModel : BaseHierarchyModel, IMapFrom<Packing, PackingModel>
    {
        public long Id { get; set; }
        public int LevelCode { get; set; }
        public string Title { get; set; }
        public double ConversionFactor { get; set; }
        public long MeasureUnitBaseId { get; set; }
    }
}
