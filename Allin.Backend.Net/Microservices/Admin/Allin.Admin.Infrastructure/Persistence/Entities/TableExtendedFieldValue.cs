using System;
using System.Collections.Generic;
using Allin.Common.Data;
namespace Allin.Admin.Infrastructure.Persistence;

public class TableExtendedFieldValue : AdminBaseEntity 
{
  public long RecordId { get; set; }
  public long TableExtendedFieldId { get; set; }
  public string? Value { get; set; }
  public long? ValueFieldItemId { get; set; }
    public virtual TableExtendedField TableExtendedField { get; set; } = null!;
}
