using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Admin.Infrastructure.Persistence;

public class Team : AdminBaseEntity , IHierarchyEntity
{
  public long? ParentId { get; set; }
  public HierarchyId? Hierarchy { get; set; }
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public SubSystemEnums? SubSystemEnum { get; set; }
  public long? RestrictedToDepartmentId { get; set; }
    public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; } = new List<EmployeeTeam>();
    public virtual Department? RestrictedToDepartment { get; set; }
}
