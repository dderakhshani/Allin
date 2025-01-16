using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public class PositionQueries : QueryBase<AdminDbContext>, IPositionQueries
    {
        public PositionQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<PositionModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Positions.AsNoTracking().ProjectTo<PositionModel>(MapperProvider).ToPagedListAsync(param);
        }
        public async Task<IEnumerable<TreeNode<PositionModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.Positions.AsNoTracking()
                                .ProjectTo<PositionModel>(MapperProvider).ToListAsync())
                                .ToTreeModel(nameof(PositionModel.Title), nameof(PositionModel.LevelCode));
        }

        public async Task<PositionModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<PositionModel>(await DbContext.Positions.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
