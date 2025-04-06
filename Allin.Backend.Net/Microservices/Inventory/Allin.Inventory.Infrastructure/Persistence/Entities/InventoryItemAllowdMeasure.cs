using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryItemAllowdMeasure : InventoryBaseEntity 
{
  public long ItemId { get; set; }
  public long MeasureUnitId { get; set; }
  public int OrderIndex { get; set; }
    public virtual InventoryItem Item { get; set; } = null!;
    public virtual MeasureUnit MeasureUnit { get; set; } = null!;
}
