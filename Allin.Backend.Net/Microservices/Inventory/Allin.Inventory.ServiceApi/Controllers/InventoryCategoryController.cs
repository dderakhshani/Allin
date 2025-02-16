
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Web;
using Allin.Inventory.Application.Commands;
using Allin.Inventory.Application.Commands.InventoryCategories.Create;
using Allin.Inventory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class InventoryCategoryController : AuthorizeApiControllerBase
    {
        private readonly IInventoryCategoryQueries _inventoryCategoryQueries;

        public InventoryCategoryController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IInventoryCategoryQueries InventoryCategoryQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _inventoryCategoryQueries = InventoryCategoryQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryCategoryQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryCategoryQueries.GetAll(param, cancellationToken));
        }

        [HttpGet("get-all-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryCategoryQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand request, CancellationToken cancellationToken)
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

        [HttpGet("get-Properties")]
        public async Task<IActionResult> GetPropertiesByCategoryId(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryCategoryQueries.GetPropertiesByCategoryId(id, cancellationToken));
        }

        [HttpGet("get-items-Property")]
        public async Task<IActionResult> GetPropertyItemsByPropertyId(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryCategoryQueries.GetPropertyItemsByPropertyId(id, cancellationToken));
        }


    }
}
