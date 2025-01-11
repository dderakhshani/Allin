using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Location : AdminBaseEntity 
{
  public long? ParentId { get; set; }
  public long LocationBaseId { get; set; }
  public string LocationTitle { get; set; } = null!;
    public virtual ICollection<Location> InverseParent { get; set; } = new List<Location>();
    public virtual Location? Parent { get; set; }
}
