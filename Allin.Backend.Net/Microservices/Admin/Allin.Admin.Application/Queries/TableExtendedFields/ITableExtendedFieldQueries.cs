using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;

namespace Allin.Admin.Application.Queries
{
    public interface ITableExtendedFieldQueries
    {
        Task<PagedList<TableExtendedFieldModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<TableExtendedFieldModel> GetById(long id, CancellationToken cancellationToken);
        Task<List<TableExtendedFieldModel>> GetByTableName(string tableName, CancellationToken cancellationToken);
    }
}
