using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>, IMapFrom<User, CreateUserCommand>
    {
        public long EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<long> RoleIds { get; set; }
        public IEnumerable<long> DeniedPermissionIds { get; set; }
    }
}
