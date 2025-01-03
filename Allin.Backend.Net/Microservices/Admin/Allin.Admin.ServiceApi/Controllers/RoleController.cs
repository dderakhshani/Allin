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

        public RoleController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IRoleQueries roleQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _roleQueries = roleQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetById(id, cancellationToken));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _roleQueries.GetAll(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }
    }
}
