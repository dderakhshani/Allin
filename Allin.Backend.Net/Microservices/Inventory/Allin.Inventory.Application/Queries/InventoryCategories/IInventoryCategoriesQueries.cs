using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;

namespace Allin.Inventory.Application.Queries
{
    public interface IInventoryCategoriesQueries
    {
        Task<PagedList<InventoryCategoryModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<InventoryCategoryModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<InventoryCategoryModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
    }
}
