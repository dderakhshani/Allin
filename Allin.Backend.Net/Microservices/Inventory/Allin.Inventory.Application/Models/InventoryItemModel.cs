using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class InventoryItemModel : BaseHierarchyModel, IMapFrom<InventoryItem, InventoryItemModel>
    {
        public string? Title { get; set; }
    }
}
