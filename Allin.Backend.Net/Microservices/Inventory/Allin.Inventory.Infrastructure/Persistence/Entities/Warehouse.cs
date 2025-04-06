using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class Warehouse : InventoryBaseEntity 
{
  public string Title { get; set; } = null!;
    public virtual ICollection<InventoryCategory> InventoryCategories { get; set; } = new List<InventoryCategory>();
}
