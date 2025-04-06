using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface ITeamQueries
    {
        Task<PagedList<TeamModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<TeamModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken);
        Task<TeamModel> GetById(long id, CancellationToken cancellationToken);
    }
}
