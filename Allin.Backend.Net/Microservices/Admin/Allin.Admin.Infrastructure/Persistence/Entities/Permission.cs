using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Admin.Infrastructure.Persistence;

public class Permission : AdminBaseEntity , IHierarchyEntity
{
  public HierarchyId? Hierarchy { get; set; }
  public long? ParentId { get; set; }
  public string Title { get; set; } = null!;
  public string UniqueName { get; set; } = null!;
  public string SubSystem { get; set; } = null!;
    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public virtual ICollection<UserDeniedPermission> UserDeniedPermissions { get; set; } = new List<UserDeniedPermission>();
}
