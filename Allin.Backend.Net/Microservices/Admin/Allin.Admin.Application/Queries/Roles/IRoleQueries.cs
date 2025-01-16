using Allin.Admin.Application.Models;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface IRoleQueries
    {
        Task<PagedList<RoleModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken);
        Task<RoleModel> GetById(long id, CancellationToken cancellationToken);
        Task<IEnumerable<PermissionModel>> GetAllPermissions(CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<PermissionModel>>> GetAllPermissionsTree(CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<PermissionModel>>> GetPermissionsTreeByRoleId(long roleId, CancellationToken cancellationToken);
    }
}
