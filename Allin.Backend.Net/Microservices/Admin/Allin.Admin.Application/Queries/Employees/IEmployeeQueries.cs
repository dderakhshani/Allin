using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IEmployeeQueries
    {
        Task<PagedList<EmployeeModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<EmployeeModel> GetById(long id, CancellationToken cancellationToken);
    }
}
