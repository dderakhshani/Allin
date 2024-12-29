using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class Department : AdminBaseEntity
{
  public long? ParentId { get; set; }
  public string Code { get; set; }
  public string Title { get; set; }
  public long BranchId { get; set; }
    public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
    public virtual ICollection<Department> InverseParent { get; set; } = new List<Department>();
    public virtual Department Parent { get; set; }
}
