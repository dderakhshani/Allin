﻿using System;
using System.Collections.Generic;
using Allin.Common.Entities;
namespace Allin.Admin.Infrastructure.Persistence;

public class PersonAddress : AdminBaseEntity 
{
  public long PersonId { get; set; }
  public long TypeBaseId { get; set; }
  public long CityBaseId { get; set; }
  public string Address { get; set; }
    public virtual Person Person { get; set; }
}