using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IUserQueries
    {
        Task<PagedList<BriefUserModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<UserModel> GetById(long id, CancellationToken cancellationToken);
    }
}
