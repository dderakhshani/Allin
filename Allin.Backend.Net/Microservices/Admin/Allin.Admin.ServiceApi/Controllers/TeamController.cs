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
    public class TeamController : AuthorizeApiControllerBase
    {
        private readonly ITeamQueries _teamQueries;

        public TeamController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, ITeamQueries TeamQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _teamQueries = TeamQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _teamQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _teamQueries.GetAll(param, cancellationToken));
        }
        [HttpGet("get-team-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _teamQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTeamCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditTeamCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteTeamCommand(id), cancellationToken);
        }

    }
}
