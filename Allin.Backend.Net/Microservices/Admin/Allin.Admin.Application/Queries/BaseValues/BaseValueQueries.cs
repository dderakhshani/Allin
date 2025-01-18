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
    public class BaseValueQueries : QueryBase<AdminDbContext>, IBaseValueQueries
    {
        public BaseValueQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<BaseValueModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.BaseValues.AsNoTracking().ProjectTo<BaseValueModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<IEnumerable<BaseValueModel>> GetAll(CancellationToken cancellationToken)
        {
            return await DbContext.BaseValues.AsNoTracking().ProjectTo<BaseValueModel>(MapperProvider).ToListAsync();
        }

        public async Task<IEnumerable<BaseValueTypeModel>> GetAllBaseValueTypes(CancellationToken cancellationToken)
        {
            return await DbContext.BaseValueTypes.AsNoTracking().ProjectTo<BaseValueTypeModel>(MapperProvider).ToListAsync();
        }

        public async Task<BaseValueModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<BaseValueModel>(await DbContext.BaseValues.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }

        public async Task<IEnumerable<BaseValueModel>> GetByValueTypeId(long valueTypeId, CancellationToken cancellationToken)
        {
            return await DbContext.BaseValues.Where(x => x.BaseValueTypeId == valueTypeId).AsNoTracking().ProjectTo<BaseValueModel>(MapperProvider).ToListAsync();
        }
    }
}
