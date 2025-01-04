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
    public class BranchQueries : QueryBase<AdminDbContext>, IBranchQueries
    {
        public BranchQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<BranchModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Branchs.AsNoTracking().ProjectTo<BranchModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<BranchModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<BranchModel>(await DbContext.Branchs.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
