using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class User : AdminBaseEntity 
{
  public long EmployeeId { get; set; }
  public string Username { get; set; } = null!;
  public bool IsBlocked { get; set; }
  public long? BlockedReasonBaseId { get; set; }
  public string Password { get; set; } = null!;
  public DateTime? PasswordExpiryDate { get; set; }
  public int FailedCount { get; set; }
  public DateTime? LastOnlineTime { get; set; }
    public virtual BaseValueItem? BlockedReasonBase { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    public virtual ICollection<UserDeniedPermission> UserDeniedPermissions { get; set; } = new List<UserDeniedPermission>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
