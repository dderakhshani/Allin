using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class EmployeeTeam : AdminBaseEntity 
{
  public long? TeamId { get; set; }
  public long? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Team? Team { get; set; }
}
