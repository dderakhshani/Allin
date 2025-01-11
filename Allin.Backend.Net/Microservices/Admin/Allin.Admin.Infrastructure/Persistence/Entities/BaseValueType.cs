using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValueType : AdminBaseEntity 
{
  public string BaseValueTypeTitle { get; set; } = null!;
  public string? Description { get; set; }
  public string? UniqueName { get; set; }
    public virtual ICollection<BaseValue> BaseValues { get; set; } = new List<BaseValue>();
}
