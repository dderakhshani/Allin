using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allin.Common;
using Allin.Common.Web;
using MediatR;

//NOTE namespace must be Allin.Admin.Application.Commands(inner folders doesn't affect the namespace)
namespace Allin.Admin.Application.Commands
{
    public class AddUserCommand : IRequest<GeneralApiResult>//, IMapFrom<User, AddUserCommand>
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
