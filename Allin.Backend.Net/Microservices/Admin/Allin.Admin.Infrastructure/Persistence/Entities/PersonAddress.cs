using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class PersonAddress : AdminBaseEntity 
{
  public long PersonId { get; set; }
  public long TypeBaseId { get; set; }
  public long CityBaseId { get; set; }
  public string Address { get; set; } = null!;
    public virtual BaseValue CityBase { get; set; } = null!;
    public virtual Person Person { get; set; } = null!;
    public virtual BaseValue TypeBase { get; set; } = null!;
}
