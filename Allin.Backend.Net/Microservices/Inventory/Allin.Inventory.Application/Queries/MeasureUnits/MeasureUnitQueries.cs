using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using Allin.Common.Utilities;
using Allin.Inventory.Application.Models;
using Allin.Inventory.Infrastructure;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Allin.Inventory.Application.Queries
{
    public class MeasureUnitQueries : QueryBase<InventoryDbContext>, IMeasureUnitQueries
    {
        public MeasureUnitQueries(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<MeasureUnitModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.MeasureUnits.AsNoTracking().ProjectTo<MeasureUnitModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<IEnumerable<TreeNode<MeasureUnitModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.MeasureUnits.AsNoTracking()
                               .ProjectTo<MeasureUnitModel>(MapperProvider).ToListAsync())
                               .ToTreeModel(nameof(MeasureUnitModel.Title), nameof(MeasureUnitModel.Id));
        }

        public async Task<MeasureUnitModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<MeasureUnitModel>(await DbContext.MeasureUnits.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
