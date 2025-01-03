using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IBranchQueries
    {
        Task<PagedList<BranchModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<BranchModel> GetById(long id, CancellationToken cancellationToken);
    }
}
