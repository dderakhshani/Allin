using Allin.Admin.Application.Commands;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class UserController : AuthorizeApiControllerBase
    {
        public UserController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment) : base(mediator, userAccessor, currentEnvironment)
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
