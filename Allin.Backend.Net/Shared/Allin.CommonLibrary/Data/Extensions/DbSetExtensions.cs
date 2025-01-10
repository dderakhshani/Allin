using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Data
{
    public static class DbSetExtensions
    {
        public static async Task<HierarchyId> GetHierarchyIdAsync<TEntity>(this DbSet<TEntity> dbSet, long? parentId)
            where TEntity : BaseEntity, IHierarchyEntity
        {
            HierarchyId hierarchyId = HierarchyId.GetRoot();

            if (!parentId.HasValue)
            {
                var lastRootHierarchy = await dbSet
                .Where(e => e.ParentId == null)
                .OrderByDescending(e => e.Hierarchy)
                .Select(e => e.Hierarchy)
                .FirstOrDefaultAsync();

                hierarchyId = lastRootHierarchy == null
                    ? HierarchyId.GetRoot().GetDescendant(null, null)
                    : lastRootHierarchy.GetAncestor(1).GetDescendant(lastRootHierarchy, null);
            }

            else
            {
                var parentHierarchy = await dbSet.Where(x => x.ParentId == parentId).MaxAsync(x => x.Hierarchy);

                if (parentHierarchy == null)
                {
                    parentHierarchy = (await dbSet.FirstAsync(x => x.Id == parentId)).Hierarchy;

                    hierarchyId = parentHierarchy.GetDescendant(null, null);
                }
                else hierarchyId = parentHierarchy.GetAncestor(1).GetDescendant(parentHierarchy, null);
            }

            return hierarchyId;
        }

    }
}
