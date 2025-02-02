using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
namespace Allin.Inventory.Infrastructure.Persistence;

public class MeasureUnit : InventoryBaseEntity, IHierarchyEntity
{
    public long? ParentId { get; set; }
    public HierarchyId? Hierarchy { get; set; }
    public string? Title { get; set; }
}
