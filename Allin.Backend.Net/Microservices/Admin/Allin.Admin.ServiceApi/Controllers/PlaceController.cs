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
    public class PlaceController : AuthorizeApiControllerBase
    {
        private readonly IPlaceQueries _placeQueries;

        public PlaceController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IPlaceQueries PlaceQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _placeQueries = PlaceQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _placeQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _placeQueries.GetAll(param, cancellationToken));
        }
        [HttpGet("get-place-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _placeQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] EditPlaceCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeletePlaceCommand(id), cancellationToken);
        }

    }
}
