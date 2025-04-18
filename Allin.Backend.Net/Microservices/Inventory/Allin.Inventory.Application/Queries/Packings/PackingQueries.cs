﻿using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Allin.Inventory.Application.Queries
{
    public class PackingQueries : QueryBase<InventoryDbContext>, IPackingQueries
    {
        public PackingQueries(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<PackingModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Packings.AsNoTracking().ProjectTo<PackingModel>(MapperProvider).ToPagedListAsync(param);
        }
        public async Task<IEnumerable<PackingModel>> GetAllByLevel(int level, CancellationToken cancellationToken)
        {
            return await DbContext.Packings.Where(x=> x.LevelCode < level).AsNoTracking().ProjectTo<PackingModel>(MapperProvider).ToListAsync();
        }

        //public async Task<IEnumerable<TreeNode<MeasureUnitModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        //{
        //    return (await DbContext.MeasureUnits.AsNoTracking()
        //                       .ProjectTo<MeasureUnitModel>(MapperProvider).ToListAsync())
        //                       .ToTreeModel(nameof(MeasureUnitModel.Title), nameof(MeasureUnitModel.Id));
        //}

        //public async Task<MeasureUnitModel> GetById(long id, CancellationToken cancellationToken)
        //{
        //    return Mapper.Map<MeasureUnitModel>(await DbContext.MeasureUnits.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        //}
    }
}
