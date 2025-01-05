using System;
using System.Collections.Generic;
using Allin.Common.Entities;
namespace Allin.Admin.Infrastructure.Persistence;

public class TableExtendedFieldValue : AdminBaseEntity 
{
  public long RecordId { get; set; }
  public long TableExtendedFieldId { get; set; }
  public string Value { get; set; }
  public string ValueFieldItemId { get; set; }
    public virtual TableExtendedField TableExtendedField { get; set; }
}
