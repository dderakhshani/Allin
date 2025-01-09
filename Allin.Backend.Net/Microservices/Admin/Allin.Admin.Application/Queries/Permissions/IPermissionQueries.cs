using Allin.Admin.Application.Models;
using Allin.Common.Utilities;

namespace Allin.Admin.Application.Queries
{
    public interface IPermissionQueries
    {
        Task<IEnumerable<PermissionModel>> GetAll(CancellationToken cancellationToken);
        Task<IEnumerable<TreeNode<PermissionModel>>> GetAllTree(CancellationToken cancellationToken);
    }
}
