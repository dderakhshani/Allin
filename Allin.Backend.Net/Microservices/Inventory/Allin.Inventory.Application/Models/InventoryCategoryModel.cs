﻿using Allin.Common.Models;
using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;

namespace Allin.Inventory.Application.Models
{
    public class InventoryCategoryModel : BaseHierarchyModel, IMapFrom<InventoryCategory, InventoryCategoryModel>
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public IEnumerable<InventoryCategoryPropertyModel>? Properties { get; set; }
    }
}
