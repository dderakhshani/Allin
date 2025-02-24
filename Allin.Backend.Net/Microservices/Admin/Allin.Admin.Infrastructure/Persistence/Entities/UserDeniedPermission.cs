﻿using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class UserDeniedPermission : AdminBaseEntity 
{
  public long UserId { get; set; }
  public long PermissionId { get; set; }
    public virtual Permission Permission { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
