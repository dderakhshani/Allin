using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class InventoryCategoryModel : BaseHierarchyModel, IMapFrom<InventoryCategory, InventoryCategoryModel>
    {
        public string? Title { get; set; }
    }
}
