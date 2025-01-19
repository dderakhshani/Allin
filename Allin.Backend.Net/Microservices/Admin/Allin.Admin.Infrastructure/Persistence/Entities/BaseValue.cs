namespace Allin.Admin.Infrastructure.Persistence;

public class BaseValue : AdminBaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? UniqueName { get; set; }
    public virtual ICollection<BaseValueItem> BaseValueItems { get; set; } = new List<BaseValueItem>();
}
