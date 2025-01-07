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
    public class EmployeeController : AuthorizeApiControllerBase
    {
        private readonly IEmployeeQueries _employeeQueries;

        public EmployeeController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IEmployeeQueries employeeQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _employeeQueries = employeeQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _employeeQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _employeeQueries.GetAll(param, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteEmployeeCommand(id), cancellationToken);
        }

    }
}
