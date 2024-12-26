using MediatR;

//NOTE namespace must be Allin.Admin.Application.Commands(inner folders doesn't affect the namespace)
namespace Allin.Admin.Application.Commands.Users.Add
{
    public class AddUserCommand : IRequest<bool>
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
