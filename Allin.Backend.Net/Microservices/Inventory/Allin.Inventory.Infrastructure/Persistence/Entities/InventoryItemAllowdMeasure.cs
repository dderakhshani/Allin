using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryItemAllowdMeasure : InventoryBaseEntity 
{
  public long ItemId { get; set; }
  public long MeasureId { get; set; }
  public int OrderIndex { get; set; }
}
