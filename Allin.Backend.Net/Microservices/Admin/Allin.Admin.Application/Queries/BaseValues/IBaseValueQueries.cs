using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface IBaseValueQueries
    {
        Task<PagedList<BaseValueItemModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueItemModel>> GetAll(CancellationToken cancellationToken);
        Task<BaseValueItemModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueItemModel>> GetByValueTypeId(long valueTypeId, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueTypeModel>> GetAllBaseValueTypes(CancellationToken cancellationToken);
    }
}
