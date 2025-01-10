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
    public class DepartmentQueries : QueryBase<AdminDbContext>, IDepartmentQueries
    {
        public DepartmentQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<DepartmentModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Departments.AsNoTracking().ProjectTo<DepartmentModel>(MapperProvider).ToPagedListAsync(param);
        }
        public async Task<IEnumerable<TreeNode<DepartmentModel>>> GetAllTree(QueryParamModel param, CancellationToken cancellationToken)
        {
            return (await DbContext.Departments.AsNoTracking().ProjectTo<DepartmentModel>(MapperProvider).ToListAsync()).ToTreeModel();
        }

        public async Task<DepartmentModel> GetById(long id, CancellationToken cancellationToken)
        {
            return Mapper.Map<DepartmentModel>(await DbContext.Departments.AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));
        }
    }
}
