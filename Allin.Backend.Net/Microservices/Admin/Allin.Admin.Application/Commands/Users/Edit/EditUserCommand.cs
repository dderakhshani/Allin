using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditUserCommand : IRequest<bool>, IMapFrom<User, EditUserCommand>
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string Username { get; set; }
        public bool IsBlocked { get; set; }
        public long? BlockedReasonBaseId { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public string? Password { get; set; }

        public IEnumerable<long> RoleIds { get; set; }
        public IEnumerable<long> DeniedPermissionIds { get; set; }
    }
}
