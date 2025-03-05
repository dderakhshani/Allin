
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Web;
using Allin.Inventory.Application.Commands.packings.Create;
using Allin.Inventory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class PakingController : AuthorizeApiControllerBase
    {
        private readonly IPackingQueries _packingQueries;

        public PakingController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IPackingQueries PackingQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _packingQueries = PackingQueries;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        //{
        //    return OkResult(await _packingQueries.GetById(id, cancellationToken));
        //}

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _packingQueries.GetAll(param, cancellationToken));
        }

        //[HttpGet("get-all-tree")]
        //public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        //{
        //    return OkResult(await _packingQueries.GetAllTree(param, cancellationToken));
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePackingCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        //[HttpPut]
        //public async Task<IActionResult> Edit([FromBody] EditMeasureUnitCommand request, CancellationToken cancellationToken)
        //{
        //    return await SendCommand(request, cancellationToken);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        //{
        //    return await SendCommand(new DeleteMeasureUnitCommand(id), cancellationToken);
        //}

    }
}
