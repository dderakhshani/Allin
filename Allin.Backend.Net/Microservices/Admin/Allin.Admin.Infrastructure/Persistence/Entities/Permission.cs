using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class Permission : AdminBaseEntity
{
  public long? ParentId { get; set; }
  public string Title { get; set; }
  public string UniqueName { get; set; }
  public string SubSystem { get; set; }
    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
