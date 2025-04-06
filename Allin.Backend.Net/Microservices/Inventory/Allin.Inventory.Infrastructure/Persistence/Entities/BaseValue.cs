using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class BaseValue : InventoryBaseEntity 
{
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public string? UniqueName { get; set; }
    public virtual ICollection<BaseValueItem> BaseValueItems { get; set; } = new List<BaseValueItem>();
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}
