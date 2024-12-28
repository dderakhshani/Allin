using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValueType : AdminBaseEntity
{
  public string BaseValueTypeTitle { get; set; }
  public string Description { get; set; }
}
