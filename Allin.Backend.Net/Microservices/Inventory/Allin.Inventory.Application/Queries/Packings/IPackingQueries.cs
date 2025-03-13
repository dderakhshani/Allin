using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;

namespace Allin.Inventory.Application.Queries
{
    public interface IPackingQueries
    {
        Task<PagedList<PackingModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<PackingModel>> GetAllByLevel(int level, CancellationToken cancellationToken);
        //Task<MeasureUnitModel> GetById(long id, CancellationToken cancellationToken);
        //Task<IEnumerable<TreeNode<MeasureUnitModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
    }
}
