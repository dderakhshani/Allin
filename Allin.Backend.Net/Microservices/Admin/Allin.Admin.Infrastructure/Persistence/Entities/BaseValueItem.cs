﻿using System;
using System.Collections.Generic;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValueItem : AdminBaseEntity , IHierarchyEntity
{
  public long BaseValueId { get; set; }
  public long? ParentId { get; set; }
  public HierarchyId? Hierarchy { get; set; }
  public string Title { get; set; } = null!;
  public short Order { get; set; }
  public int Value { get; set; }
  public string? Description { get; set; }
    public virtual BaseValue BaseValue { get; set; } = null!;
}
