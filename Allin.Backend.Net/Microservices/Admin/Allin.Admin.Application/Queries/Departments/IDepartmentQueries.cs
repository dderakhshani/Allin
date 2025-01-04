using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IDepartmentQueries
    {
        Task<PagedList<DepartmentModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<DepartmentModel> GetById(long id, CancellationToken cancellationToken);
    }
}
