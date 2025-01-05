using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Queries
{
    public class TableExtendedFieldQueries : QueryBase<AdminDbContext>, ITableExtendedFieldQueries
    {
        public TableExtendedFieldQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<TableExtendedFieldModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.TableExtendedFields.Include(x => x.TableExtendedFieldItems).AsNoTracking().ProjectTo<TableExtendedFieldModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<TableExtendedFieldModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<TableExtendedFieldModel>(await DbContext.TableExtendedFields.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
