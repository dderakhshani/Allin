using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Admin.Infrastructure.Persistence;

public class Department : AdminBaseEntity, IHierarchyEntity
{
    public HierarchyId Hierarchy { get; set; }
    public long? ParentId { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public long BranchId { get; set; }
    public virtual Branch Branch { get; set; }
    public virtual ICollection<DepartmentPosition> DepartmentPositions { get; set; } = new List<DepartmentPosition>();
    public virtual ICollection<Department> InverseParent { get; set; } = new List<Department>();
    public virtual Department Parent { get; set; }
}
