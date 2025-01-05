namespace Allin.Admin.Infrastructure.Persistence;

public class TableExtendedFieldItem : AdminBaseEntity
{
    public long TableExtendedFieldsId { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public string UniqueName { get; set; }
    public string Value { get; set; }
    public int OrderIndex { get; set; }
    public virtual TableExtendedField TableExtendedFields { get; set; }
}
