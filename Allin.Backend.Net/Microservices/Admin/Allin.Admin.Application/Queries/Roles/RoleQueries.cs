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
    public class RoleQueries : QueryBase<AdminDbContext>, IRoleQueries
    {
        public RoleQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<RoleModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Roles.AsNoTracking().ProjectTo<RoleModel>(MapperProvider).ToPagedListAsync(param, cancellationToken);
        }

        public async Task<RoleModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<RoleModel>(await DbContext.Roles.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
