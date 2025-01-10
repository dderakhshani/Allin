using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Role : AdminBaseEntity
{
    public string Title { get; set; }
    public string UniqueName { get; set; }
    public string Description { get; set; }
    public long? DepartmentId { get; set; }
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
