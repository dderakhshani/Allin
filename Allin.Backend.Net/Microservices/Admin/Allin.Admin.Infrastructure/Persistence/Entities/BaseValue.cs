namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValue : AdminBaseEntity
{
    public long BaseValueTypeId { get; set; }
    public long? ParentId { get; set; }
    public string BaseValueTitle { get; set; }
    public short Order { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
}
