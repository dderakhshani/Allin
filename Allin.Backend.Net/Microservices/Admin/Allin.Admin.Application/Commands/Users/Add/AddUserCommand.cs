using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

//NOTE namespace must be Allin.Admin.Application.Commands(inner folders doesn't affect the namespace)
namespace Allin.Admin.Application.Commands
{
    public class AddUserCommand : IRequest<bool>, IMapFrom<User, AddUserCommand>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        public required List<AddUserCommandRoles> Roles { get; set; }

    }



    public class AddUserCommandRoles
    {
        public required long RoleId { get; set; }
    }
}
