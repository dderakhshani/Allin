using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Utilities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Queries
{
    public class PermissionQueries : QueryBase<AdminDbContext>, IPermissionQueries
    {
        public PermissionQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<PermissionModel>> GetAll(CancellationToken cancellationToken)
        {
            return await DbContext.Permissions.AsNoTracking().ProjectTo<PermissionModel>(MapperProvider).ToListAsync();
        }

        public async Task<IEnumerable<TreeNode<PermissionModel>>> GetAllTree(CancellationToken cancellationToken)
        {
            return (await this.GetAll(cancellationToken)).ToTreeModel(nameof(PermissionModel.Title), nameof(PermissionModel.UniqueName));
        }
    }
}
