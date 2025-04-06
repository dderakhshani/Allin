using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class Place : InventoryBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId Hierarchy { get; set; } = null!;
  public long? PlaceBaseId { get; set; }
  public string PlaceTitle { get; set; } = null!;
    public virtual ICollection<Place> InverseParent { get; set; } = new List<Place>();
    public virtual Place? Parent { get; set; }
}
