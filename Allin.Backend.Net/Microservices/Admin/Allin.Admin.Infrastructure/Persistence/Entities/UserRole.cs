﻿using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class UserRole : AdminBaseEntity 
{
  public long RoleId { get; set; }
  public long UserId { get; set; }
  public bool AllowedStatus { get; set; }
    public virtual Role Role { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
