using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface IPositionQueries
    {
        Task<PagedList<PositionModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<PositionModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
        Task<PositionModel> GetById(long id, CancellationToken cancellationToken);
    }
}
