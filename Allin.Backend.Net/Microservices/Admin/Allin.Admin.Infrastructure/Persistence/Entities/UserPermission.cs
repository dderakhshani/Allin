using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class UserPermission : AdminBaseEntity
{
  public long UserId { get; set; }
  public long PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
    public virtual User User { get; set; }
}
