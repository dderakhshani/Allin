using Allin.Common.Data;
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
    public class InventoryItemQueries : QueryBase<InventoryDbContext>, IInventoryItemQueries
    {
        public InventoryItemQueries(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<InventoryItemModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.InventoryItems.AsNoTracking().ProjectTo<InventoryItemModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<IEnumerable<TreeNode<InventoryItemModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.InventoryItems.AsNoTracking()
                               .ProjectTo<InventoryItemModel>(MapperProvider).ToListAsync())
                               .ToTreeModel(nameof(InventoryItemModel.Title), nameof(InventoryItemModel.Id));
        }

        public async Task<InventoryItemModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<InventoryItemModel>(await DbContext.InventoryItems.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
