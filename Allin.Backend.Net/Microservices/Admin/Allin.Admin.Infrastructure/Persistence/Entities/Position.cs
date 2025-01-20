using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Admin.Infrastructure.Persistence;

public class Position : AdminBaseEntity , IHierarchyEntity
{
  public HierarchyId Hierarchy { get; set; } = null!;
  public long? ParentId { get; set; }
  public string Title { get; set; } = null!;
    public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
    public virtual ICollection<Position> InverseParent { get; set; } = new List<Position>();
    public virtual Position? Parent { get; set; }
}
