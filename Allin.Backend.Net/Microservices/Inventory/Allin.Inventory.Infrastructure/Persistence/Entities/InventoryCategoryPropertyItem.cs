namespace Allin.Inventory.Infrastructure.Persistence;

public class InventoryCategoryPropertyItem : InventoryBaseEntity
{
  public long CategoryPropertyId { get; set; }
  public long? ParentId { get; set; }
  public string Title { get; set; } = null!;
  public string UniqueName { get; set; } = null!;
  public string? Code { get; set; }
  public int OrderIndex { get; set; }
  public bool IsActive { get; set; }
    public virtual InventoryCategoryProperty CategoryProperty { get; set; } = null!;
}
