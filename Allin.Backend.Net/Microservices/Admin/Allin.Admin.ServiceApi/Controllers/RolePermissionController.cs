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
    public class RolePermissionController : AuthorizeApiControllerBase
    {
        private readonly IRoleQueries _roleQueries;

        public RolePermissionController(IMediator mediator,
            IUserAccessor userAccessor,
            IWebHostEnvironment currentEnvironment,
            IRoleQueries roleQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _roleQueries = roleQueries;
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

        [HttpGet("get-permissions-tree")]
        public async Task<IActionResult> GetPermissions(CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetAllPermissionsTree(cancellationToken));
        }

        [HttpGet("get-permissions-tree-by-role-id/{roleId}")]
        public async Task<IActionResult> GetPermissions(long roleId, CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetPermissionsTreeByRoleId(roleId, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut("edit")]
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
