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
    public class PlaceQueries : QueryBase<AdminDbContext>, IPlaceQueries
    {
        public PlaceQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<PlaceModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Places.AsNoTracking().ProjectTo<PlaceModel>(MapperProvider).ToPagedListAsync(param);
        }
        public async Task<IEnumerable<TreeNode<PlaceModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.Places.AsNoTracking().ProjectTo<PlaceModel>(MapperProvider).ToListAsync()).ToTreeModel(nameof(PlaceModel.PlaceTitle), nameof(PlaceModel.Id));
        }

        public async Task<PlaceModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<PlaceModel>(await DbContext.Places.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
