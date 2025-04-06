using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryPropertyRange : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId? Hierarchy { get; set; }
  public long CategoryPropertyId { get; set; }
  public long? InventoryItemId { get; set; }
  public long? AssetId { get; set; }
    /// <summary>
    /// null means no title, e.g. Major, critical,danger,...
    /// </summary>
  public string? RangeTitle { get; set; }
  public string MinValue { get; set; } = null!;
  public string MaxValue { get; set; } = null!;
  public bool HasAlarm { get; set; }
  public bool IsActive { get; set; }
    public virtual InventoryCategoryProperty CategoryProperty { get; set; } = null!;
    public virtual InventoryItem? InventoryItem { get; set; }
}
