using System;
using System.Collections.Generic;
namespace Allin.SharedCore.Persistence;

public class AuditedField : SharedBaseEntity
{
  public long AuditId { get; set; }
  public string FieldName { get; set; }
  public string OldValue { get; set; }
  public string NewValue { get; set; }
    public virtual Audit Audit { get; set; }
}
