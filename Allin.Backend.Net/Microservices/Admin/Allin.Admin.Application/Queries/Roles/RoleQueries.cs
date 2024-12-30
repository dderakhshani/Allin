using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Allin.Admin.Application.Queries
{
    public class RoleQueries : QueryBase<AdminDbContext>, IRoleQueries
    {
        public RoleQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<RoleModel>> Filter(RoleFilterParam param)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<RoleModel>> GetAll(QueryParamModel param)
        {
            return await DbContext.Roles.ProjectTo<RoleModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<RoleModel> GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
