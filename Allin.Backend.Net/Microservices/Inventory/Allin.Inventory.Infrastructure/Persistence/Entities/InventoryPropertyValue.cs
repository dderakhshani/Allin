using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryPropertyValue : InventoryBaseEntity 
{
  public long ItemId { get; set; }
  public long CategoryPropertyId { get; set; }
  public long? ValuePropertyItemId { get; set; }
  public string? Value { get; set; }
    public virtual InventoryCategoryProperty CategoryProperty { get; set; } = null!;
    public virtual InventoryItem Item { get; set; } = null!;
}
