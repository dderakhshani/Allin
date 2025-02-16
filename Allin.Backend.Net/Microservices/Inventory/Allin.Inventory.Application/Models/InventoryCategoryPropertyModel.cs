using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class InventoryCategoryPropertyModel : BaseHierarchyModel, IMapFrom<InventoryCategoryProperty, InventoryCategoryPropertyModel>
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public IEnumerable<InventoryCategoryPropertyItemModel>? items { get; set; }
    }
}
