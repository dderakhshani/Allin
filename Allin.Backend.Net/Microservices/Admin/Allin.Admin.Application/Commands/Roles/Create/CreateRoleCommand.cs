using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateRoleCommand : IRequest<bool>, IMapFrom<Role, CreateRoleCommand>
    {
        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }
        public long? DepartmentId { get; set; }
        public IEnumerable<long> PermissionIds { get; set; }
    }

    //public class RolePermissionArg : IMapFrom<RolePermission, RolePermissionArg>
    //{
    //    public long RoleId { get; set; }
    //    public long PermissionId { get; set; }
    //    public Permission Permission { get; set; }
    //    public Role Role { get; set; }
    //}
}