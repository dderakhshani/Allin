using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;

namespace Allin.Inventory.Application.Queries
{
    public interface IInventoryCategoryQueries
    {
        Task<PagedList<InventoryCategoryModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<InventoryCategoryModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<InventoryCategoryModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
        Task<List<InventoryCategoryPropertyModel>> GetPropertiesByCategoryId(long id, CancellationToken cancellationToken);
        Task<List<InventoryCategoryPropertyItemModel>> GetPropertyItemsByPropertyId(long id, CancellationToken cancellationToken);
    }
}
