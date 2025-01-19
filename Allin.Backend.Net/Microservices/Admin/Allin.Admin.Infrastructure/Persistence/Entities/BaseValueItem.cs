namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValueItem : AdminBaseEntity
{
    public long BaseValueId { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; } = null!;
    public short Order { get; set; }
    public int Value { get; set; }
    public string? Description { get; set; } = null!;
    public virtual BaseValue BaseValue { get; set; } = null!;
}
