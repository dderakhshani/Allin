using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryAllowdMeasure : InventoryBaseEntity 
{
  public long CategoryId { get; set; }
  public long MeasureUnitId { get; set; }
  public int OrderIndex { get; set; }
    public virtual InventoryCategory Category { get; set; } = null!;
    public virtual MeasureUnit MeasureUnit { get; set; } = null!;
}
