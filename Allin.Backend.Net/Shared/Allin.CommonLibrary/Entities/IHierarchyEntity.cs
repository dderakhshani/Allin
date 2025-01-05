using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Entities
{
    public interface IHierarchyEntity
    {
        HierarchyId Hierarchy { get; set; }
        long? ParentId { get; set; }
    }
}
