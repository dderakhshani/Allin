using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryProperty : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public long? CategoryId { get; set; }
  public HierarchyId Hierarchy { get; set; } = null!;
  public string UniqueName { get; set; } = null!;
  public string Title { get; set; } = null!;
  public long? MeasureId { get; set; }
  public long? PropertyTypeBaseId { get; set; }
  public int OrderIndex { get; set; }
    public virtual InventoryCategory? Category { get; set; }
    public virtual ICollection<InventoryCategoryPropertyItem> InventoryCategoryPropertyItems { get; set; } = new List<InventoryCategoryPropertyItem>();
    public virtual ICollection<InventoryPropertyValue> InventoryPropertyValues { get; set; } = new List<InventoryPropertyValue>();
}
