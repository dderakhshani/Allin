using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategory : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId Hierarchy { get; set; } = null!;
  public string Title { get; set; } = null!;
  public string Code { get; set; } = null!;
  public short DefaultCodingMechanism { get; set; }
    /// <summary>
    /// Assets(Machines,...), Consumable, Salable Product
    /// </summary>
  public long? ItemsTypeId { get; set; }
  public long? MeasureUnitId { get; set; }
  public long? DefaultWarehouseId { get; set; }
  public string? Description { get; set; }
    public virtual ICollection<InventoryCategoryProperty> InventoryCategoryProperties { get; set; } = new List<InventoryCategoryProperty>();
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    public virtual ICollection<InventoryCategory> InverseParent { get; set; } = new List<InventoryCategory>();
    public virtual InventoryCategory? Parent { get; set; }
}
