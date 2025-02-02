using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;

namespace Allin.Inventory.Application.Queries
{
    public interface IMeasureUnitQueries
    {
        Task<PagedList<MeasureUnitModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<MeasureUnitModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<MeasureUnitModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
    }
}
