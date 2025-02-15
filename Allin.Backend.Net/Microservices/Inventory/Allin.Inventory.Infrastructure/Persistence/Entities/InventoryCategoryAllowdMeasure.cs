using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryAllowdMeasure : InventoryBaseEntity 
{
  public long CategoryId { get; set; }
  public long MeasureId { get; set; }
  public int OrderIndex { get; set; }
}
