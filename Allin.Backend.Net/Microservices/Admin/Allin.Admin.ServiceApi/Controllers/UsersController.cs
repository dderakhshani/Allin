using Allin.Admin.Application.Commands.Users.Add;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    public class UsersController : AuthorizeApiControllerBase
    {
        public UsersController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment) : base(mediator, userAccessor, currentEnvironment)
        {
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommand command, CancellationToken cancellationToken)
        {
            return await SendCommand(command, cancellationToken);
        }
    }
}
