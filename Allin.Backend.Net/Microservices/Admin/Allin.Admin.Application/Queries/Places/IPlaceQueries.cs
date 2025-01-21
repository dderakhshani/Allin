using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface IPlaceQueries
    {
        Task<PagedList<PlaceModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<PlaceModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
        Task<PlaceModel> GetById(long id, CancellationToken cancellationToken);
    }
}
