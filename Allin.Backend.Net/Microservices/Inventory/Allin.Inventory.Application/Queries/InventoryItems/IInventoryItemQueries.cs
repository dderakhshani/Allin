using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;

namespace Allin.Inventory.Application.Queries
{
    public interface IInventoryItemQueries
    {
        Task<PagedList<InventoryItemModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<InventoryItemModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<InventoryItemModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
    }
}
