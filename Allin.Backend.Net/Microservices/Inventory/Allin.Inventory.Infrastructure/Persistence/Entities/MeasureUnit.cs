using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class MeasureUnit : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId? Hierarchy { get; set; }
  public string? Title { get; set; }
    public virtual ICollection<InventoryCategory> InventoryCategories { get; set; } = new List<InventoryCategory>();
    public virtual ICollection<InventoryCategoryAllowdMeasure> InventoryCategoryAllowdMeasures { get; set; } = new List<InventoryCategoryAllowdMeasure>();
    public virtual ICollection<InventoryCategoryProperty> InventoryCategoryProperties { get; set; } = new List<InventoryCategoryProperty>();
    public virtual ICollection<InventoryItemAllowdMeasure> InventoryItemAllowdMeasures { get; set; } = new List<InventoryItemAllowdMeasure>();
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}
