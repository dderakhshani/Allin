using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IRoleQueries
    {
        Task<PagedList<RoleModel>> GetAll(QueryParamModel param);
        Task<IEnumerable<RoleModel>> Filter(RoleFilterParam param);
        Task<RoleModel> GetById(long id);
    }
}
