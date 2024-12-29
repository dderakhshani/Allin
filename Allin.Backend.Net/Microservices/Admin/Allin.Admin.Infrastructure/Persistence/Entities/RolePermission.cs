using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class RolePermission : AdminBaseEntity
{
  public long RoleId { get; set; }
  public long PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
    public virtual Role Role { get; set; }
}
