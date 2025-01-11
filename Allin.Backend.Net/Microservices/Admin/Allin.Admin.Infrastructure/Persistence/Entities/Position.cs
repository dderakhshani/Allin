using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Position : AdminBaseEntity 
{
  public long? ParentId { get; set; }
  public string LevelCode { get; set; } = null!;
  public string Title { get; set; } = null!;
    public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
    public virtual ICollection<Position> InverseParent { get; set; } = new List<Position>();
    public virtual Position? Parent { get; set; }
}
