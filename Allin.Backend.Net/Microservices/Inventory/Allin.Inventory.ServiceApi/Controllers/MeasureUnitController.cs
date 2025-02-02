
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Web;
using Allin.Inventory.Application.Commands;
using Allin.Inventory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class MeasureUnitController : AuthorizeApiControllerBase
    {
        private readonly IMeasureUnitQueries _measureUnitQueries;

        public MeasureUnitController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IMeasureUnitQueries MeasureUnitQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _measureUnitQueries = MeasureUnitQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _measureUnitQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _measureUnitQueries.GetAll(param, cancellationToken));
        }

        [HttpGet("get-all-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _measureUnitQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteMeasureUnitCommand(id), cancellationToken);
        }

    }
}
