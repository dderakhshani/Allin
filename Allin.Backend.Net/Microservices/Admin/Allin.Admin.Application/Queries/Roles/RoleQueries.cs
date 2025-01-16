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

        public async Task<IEnumerable<PermissionModel>> GetAllPermissions(CancellationToken cancellationToken)
        {
            return await DbContext.Permissions.AsNoTracking().ProjectTo<PermissionModel>(MapperProvider).ToListAsync();
        }

        public async Task<IEnumerable<TreeNode<PermissionModel>>> GetAllPermissionsTree(CancellationToken cancellationToken)
        {
            return (await this.GetAllPermissions(cancellationToken)).ToTreeModel(nameof(PermissionModel.Title), nameof(PermissionModel.UniqueName));
        }

        public async Task<IEnumerable<TreeNode<PermissionModel>>> GetPermissionsTreeByRoleId(long roleId, CancellationToken cancellationToken)
        {
            var rolePermissions = await (from p in DbContext.Permissions
                                         join rp in DbContext.RolePermissions on p.Id equals rp.PermissionId
                                         where rp.RoleId == roleId
                                         select p)
                                        .AsNoTracking()
                                        .ProjectTo<PermissionModel>(MapperProvider)
                                        .ToListAsync();
            return rolePermissions.ToTreeModel(nameof(PermissionModel.Title), nameof(PermissionModel.UniqueName));
        }
    }
}
