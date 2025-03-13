using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface IBaseValueQueries
    {
        Task<PagedList<BaseValueItemModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueItemModel>> GetAll(CancellationToken cancellationToken);
        Task<BaseValueItemModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<BaseValueItemModel>>> GetByBaseValueId(long valueTypeId, CancellationToken cancellationToken);
        Task<IEnumerable<BaseValueItemModel>> GetByValueTypeIdList(long valueTypeId, CancellationToken cancellationToken);
        Task<PagedList<BaseValueModel>> GetAllBaseValueTypes(QueryParamModel param, CancellationToken cancellationToken);
    }
}
