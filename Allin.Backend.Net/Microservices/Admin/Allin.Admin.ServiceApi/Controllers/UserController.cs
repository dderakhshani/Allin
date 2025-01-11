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
    public class UserController : AuthorizeApiControllerBase
    {
        private readonly IUserQueries _userQueries;

        public UserController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IUserQueries userQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _userQueries = userQueries;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _userQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _userQueries.GetAll(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await SendCommand(command, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteUserCommand(id), cancellationToken);
        }
    }
}
