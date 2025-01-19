using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IBaseValueQueries
    {
        Task<PagedList<BaseValueModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueModel>> GetAll(CancellationToken cancellationToken);
        Task<BaseValueModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueModel>> GetByValueTypeId(long valueTypeId, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueTypeModel>> GetAllBaseValueTypes(CancellationToken cancellationToken);
    }
}
