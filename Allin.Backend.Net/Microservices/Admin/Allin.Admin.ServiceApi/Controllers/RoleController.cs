using Allin.Admin.Application.Commands;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class RoleController : AuthorizeApiControllerBase
    {
        public RoleController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment) : base(mediator, userAccessor, currentEnvironment)
        {

        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoleCommand command, CancellationToken cancellationToken)
        {
            return await SendCommand(command, cancellationToken);
        }
    }
}
