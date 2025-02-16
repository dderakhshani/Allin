using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryItem : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId Hierarchy { get; set; } = null!;
  public string ItemTitle { get; set; } = null!;
  public string Code { get; set; } = null!;
  public string? Code2 { get; set; }
  public string? Code3 { get; set; }
  public string? Code4 { get; set; }
  public long CategoryId { get; set; }
  public long StatusBaseId { get; set; }
  public long MeasureUnitId { get; set; }
    /// <summary>
    /// Assets(Machines,...), Consumable, Salable Product
    /// </summary>
  public long ItemTypeId { get; set; }
  public string? Description { get; set; }
  public string? Manufacturer { get; set; }
  public string? ModelNumber { get; set; }
  public int? LifeTimeHours { get; set; }
    public virtual InventoryCategory Category { get; set; } = null!;
    public virtual ICollection<InventoryPropertyValue> InventoryPropertyValues { get; set; } = new List<InventoryPropertyValue>();
}
