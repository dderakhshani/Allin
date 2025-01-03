using Allin.Admin.Application.Models;

namespace Allin.Admin.Application.Queries
{
    public interface IPermissionQueries
    {
        Task<IEnumerable<PermissionModel>> GetAll(CancellationToken cancellationToken);
    }
}
