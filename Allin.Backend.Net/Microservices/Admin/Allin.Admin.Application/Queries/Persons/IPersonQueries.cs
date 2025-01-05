using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IPersonQueries
    {
        Task<PagedList<PersonModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<PersonModel> GetById(long id, CancellationToken cancellationToken);
    }
}
