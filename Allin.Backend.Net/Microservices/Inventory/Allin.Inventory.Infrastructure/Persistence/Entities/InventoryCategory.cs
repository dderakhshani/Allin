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
  public ItemsTypeEnums? ItemsTypeEnum { get; set; }
  public long? MeasureUnitId { get; set; }
  public long? DefaultWarehouseId { get; set; }
  public string? Description { get; set; }
    /// <summary>
    /// Operational, Breakdown, Maintenance, Idle
    /// </summary>
  public OparetionStatusEnums? OparetionStatusEnum { get; set; }
    public virtual Warehouse? DefaultWarehouse { get; set; }
    public virtual ICollection<InventoryCategoryAllowdMeasure> InventoryCategoryAllowdMeasures { get; set; } = new List<InventoryCategoryAllowdMeasure>();
    public virtual ICollection<InventoryCategoryProperty> InventoryCategoryProperties { get; set; } = new List<InventoryCategoryProperty>();
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    public virtual MeasureUnit? MeasureUnit { get; set; }
    public virtual ICollection<Packing> Packings { get; set; } = new List<Packing>();
}
