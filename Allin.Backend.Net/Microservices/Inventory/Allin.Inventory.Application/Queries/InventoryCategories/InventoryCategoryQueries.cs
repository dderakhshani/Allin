﻿using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Allin.Inventory.Application.Queries
{
    public class InventoryCategoryQueries : QueryBase<InventoryDbContext>, IInventoryCategoryQueries
    {
        public InventoryCategoryQueries(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<InventoryCategoryModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.InventoryCategories.AsNoTracking().ProjectTo<InventoryCategoryModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<IEnumerable<TreeNode<InventoryCategoryModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.InventoryCategories.AsNoTracking()
                               .ProjectTo<InventoryCategoryModel>(MapperProvider).ToListAsync())
                               .ToTreeModel(nameof(InventoryCategoryModel.Title), nameof(InventoryCategoryModel.Id));
        }

        public async Task<InventoryCategoryModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<InventoryCategoryModel>(await DbContext.InventoryCategories.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }

        public async Task<List<InventoryCategoryPropertyModel>> GetPropertiesByCategoryId(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<List<InventoryCategoryPropertyModel>>(await DbContext.InventoryCategoryProperties.AsNoTracking().Where(x => x.CategoryId == id).ProjectTo<InventoryCategoryPropertyModel>(MapperProvider).ToListAsync(cancellationToken));
        }

        public async Task<List<InventoryCategoryPropertyItemModel>> GetPropertyItemsByPropertyId(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<List<InventoryCategoryPropertyItemModel>>(await DbContext.InventoryCategoryPropertyItems.AsNoTracking().Where(x => x.CategoryPropertyId == id).ProjectTo<InventoryCategoryPropertyItemModel>(MapperProvider).ToListAsync(cancellationToken));
        }
    }
}
