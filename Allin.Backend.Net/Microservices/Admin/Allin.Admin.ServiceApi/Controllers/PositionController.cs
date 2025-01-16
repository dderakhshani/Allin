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
    public class PositionController : AuthorizeApiControllerBase
    {
        private readonly IPositionQueries _postionQueries;

        public PositionController(IMediator mediator, IUserAccessor userAccessor,
                        IWebHostEnvironment currentEnvironment,
                        IPositionQueries postionQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _postionQueries = postionQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _postionQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _postionQueries.GetAll(param, cancellationToken));
        }
        [HttpGet("get-all-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _postionQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePositionCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditPositionCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeletePositionCommand(id), cancellationToken);
        }

    }
}
