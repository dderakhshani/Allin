using Allin.Admin.Application.Commands;
using Allin.Admin.Application.Queries;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class BaseValueController : AuthorizeApiControllerBase
    {
        private readonly IBaseValueQueries _baseValueQueries;

        public BaseValueController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IBaseValueQueries baseValueQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _baseValueQueries = baseValueQueries;
        }

        [OutputCache(Duration = 120)]
        [HttpGet("get-cached")]
        public async Task<IActionResult> GetCached(CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetAll(cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-items/{baseValueId}")]
        public async Task<IActionResult> GetByValueTypeId(long baseValueId, CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetByBaseValueId(baseValueId, cancellationToken));
        }

        [HttpGet("get-all-type-values")]
        public async Task<IActionResult> GetAllTypeValues(CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetAllBaseValueTypes(cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBaseValueCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] AddBaseValueItemCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditBaseValueCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteBaseValueCommand(id), cancellationToken);
        }

        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteBaseValueItemCommand(id), cancellationToken);
        }


    }
}
