using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryItemType : InventoryBaseEntity 
{
  public string ItemTypeName { get; set; } = null!;
  public bool? IsOperational { get; set; }
  public string? Description { get; set; }
}
