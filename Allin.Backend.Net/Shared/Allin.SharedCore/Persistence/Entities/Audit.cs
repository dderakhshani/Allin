namespace Allin.SharedCore.Persistence;

public class Audit : SharedBaseEntity
{
    public long? ParentAuditId { get; set; }
    /// <summary>
    /// 1=Insert,2=Edit, 3=Delete
    /// </summary>
    public short Action { get; set; }
    public string TableName { get; set; }
    public long RecordId { get; set; }
    public string OldRowJson { get; set; }
    public string NewRowJson { get; set; }
    public long CreatedBy { get; set; }
    public virtual ICollection<AuditedField> AuditedFields { get; set; } = new List<AuditedField>();
}
