using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class InventoryCategoryPropertyItemModel : BaseHierarchyModel, IMapFrom<InventoryCategoryPropertyItem, InventoryCategoryPropertyItemModel>
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long CategoryPropertyId { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Code { get; set; }
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }

    }
}
