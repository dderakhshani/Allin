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
    public class BranchController : AuthorizeApiControllerBase
    {
        private readonly IBranchQueries _branchQueries;

        public BranchController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IBranchQueries branchQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _branchQueries = branchQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _branchQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _branchQueries.GetAll(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBranchCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditBranchCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteBranchCommand(id), cancellationToken);
        }

    }
}
