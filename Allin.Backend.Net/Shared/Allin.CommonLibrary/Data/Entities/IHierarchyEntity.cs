using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Data
{
    public interface IHierarchyEntity
    {
        HierarchyId Hierarchy { get; set; }
        long? ParentId { get; set; }
    }
}
