using System;
using System.Collections.Generic;
using Allin.Common.Entities;
namespace Allin.Admin.Infrastructure.Persistence;

public class User : AdminBaseEntity 
{
  public long PersonId { get; set; }
  public string Username { get; set; }
  public bool IsBlocked { get; set; }
  public long? BlockedReasonBaseId { get; set; }
  public string Password { get; set; }
  public DateTime? PasswordExpiryDate { get; set; }
  public int FailedCount { get; set; }
  public DateTime? LastOnlineTime { get; set; }
    public virtual Person Person { get; set; }
    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
