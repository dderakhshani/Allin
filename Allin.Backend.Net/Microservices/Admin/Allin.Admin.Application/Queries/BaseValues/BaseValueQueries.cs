﻿using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using Allin.Common.Utilities;
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

        public async Task<PagedList<BaseValueItemModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.BaseValueItems.AsNoTracking().ProjectTo<BaseValueItemModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<IEnumerable<BaseValueItemModel>> GetAll(CancellationToken cancellationToken)
        {
            return await DbContext.BaseValueItems.AsNoTracking().ProjectTo<BaseValueItemModel>(MapperProvider).ToListAsync();
        }

        public async Task<PagedList<BaseValueModel>> GetAllBaseValueTypes(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.BaseValues.AsNoTracking().ProjectTo<BaseValueModel>(MapperProvider).ToPagedListAsync(param, cancellationToken);
        }

        public async Task<BaseValueItemModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<BaseValueItemModel>(await DbContext.BaseValueItems.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }

        public async Task<IEnumerable<TreeNode<BaseValueItemModel>>> GetByBaseValueId(long valueTypeId, CancellationToken cancellationToken)
        {
            return (await DbContext.BaseValueItems.Where(x => x.BaseValueId == valueTypeId).AsNoTracking().ProjectTo<BaseValueItemModel>(MapperProvider).ToListAsync()).ToTreeModel(nameof(BaseValueItemModel.Title), nameof(BaseValueItemModel.Id));
        }

        public async Task<IEnumerable<BaseValueItemModel>> GetByValueTypeIdList(long valueTypeId, CancellationToken cancellationToken)
        {
            return await DbContext.BaseValueItems.Where(x => x.BaseValueId == valueTypeId).AsNoTracking().ProjectTo<BaseValueItemModel>(MapperProvider).ToListAsync();
        }
    }
}
