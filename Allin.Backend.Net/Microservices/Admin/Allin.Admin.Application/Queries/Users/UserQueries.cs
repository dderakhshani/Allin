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
    public class UserQueries : QueryBase<AdminDbContext>, IUserQueries
    {
        public UserQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<BriefUserModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Users.Include(x => x.Employee).ThenInclude(x => x.Person).AsNoTracking().ProjectTo<BriefUserModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<UserModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<UserModel>(await DbContext.Users.Include(x => x.UserRoles).Include(x => x.UserDeniedPermissions).AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
