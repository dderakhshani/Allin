using System;
using System.Collections.Generic;
using Allin.Common.Entities;
namespace Allin.Admin.Infrastructure.Persistence;

public class DepartmentPosition : AdminBaseEntity 
{
  public long PositionId { get; set; }
  public long DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public virtual Position Position { get; set; }
}
