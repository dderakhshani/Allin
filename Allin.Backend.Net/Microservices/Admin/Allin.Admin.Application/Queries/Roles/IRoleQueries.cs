using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IRoleQueries
    {
        Task<PagedList<RoleModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<RoleModel> GetById(long id, CancellationToken cancellationToken);
    }
}
