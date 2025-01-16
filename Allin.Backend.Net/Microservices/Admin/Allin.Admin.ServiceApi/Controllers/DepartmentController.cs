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
    public class DepartmentController : AuthorizeApiControllerBase
    {
        private readonly IDepartmentQueries _departmentQueries;

        public DepartmentController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IDepartmentQueries departmentQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _departmentQueries = departmentQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _departmentQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _departmentQueries.GetAll(param, cancellationToken));
        }
        [HttpGet("get-department-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _departmentQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteDepartmentCommand(id), cancellationToken);
        }

    }
}
