using System;
using System.Collections.Generic;
namespace Allin.Admin.Infrastructure.Persistence;

public class TableExtendedFieldValue : AdminBaseEntity
{
  public long TableExtendedFieldId { get; set; }
  public string Value { get; set; }
  public string ValueFieldItemId { get; set; }
    public virtual TableExtendedField TableExtendedField { get; set; }
}
