using Allin.Admin.Application.Commands;
using Allin.Admin.Application.Queries;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class RoleController : AuthorizeApiControllerBase
    {
        private readonly IRoleQueries _roleQueries;
        private readonly IPermissionQueries _permissionQueries;

        public RoleController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IRoleQueries roleQueries, IPermissionQueries permissionQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _roleQueries = roleQueries;
            _permissionQueries = permissionQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetAll(param, cancellationToken));
        }

        [HttpGet("get-permissions")]
        public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken)
        {
            return OkResult(await _permissionQueries.GetAll(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteRoleCommand(id), cancellationToken);
        }

    }
}
