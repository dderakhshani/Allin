using Allin.Admin.Application.Models;
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
    public class TeamQueries : QueryBase<AdminDbContext>, ITeamQueries
    {
        public TeamQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<TeamModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Teams.AsNoTracking().ProjectTo<TeamModel>(MapperProvider).ToPagedListAsync(param);
        }
        public async Task<IEnumerable<TreeNode<TeamModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.Teams.AsNoTracking().ProjectTo<TeamModel>(MapperProvider).ToListAsync()).ToTreeModel(nameof(TeamModel.PlaceTitle), nameof(TeamModel.Id));
        }

        public async Task<TeamModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<TeamModel>(await DbContext.Teams.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
