using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class Branch : AdminBaseEntity 
{
  public string Title { get; set; } = null!;
  public string UniqueName { get; set; } = null!;
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
