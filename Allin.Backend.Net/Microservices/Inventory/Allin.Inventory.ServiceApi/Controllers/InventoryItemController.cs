﻿
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
    public class InventoryItemController : AuthorizeApiControllerBase
    {
        private readonly IInventoryItemQueries _inventoryItemQueries;

        public InventoryItemController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IInventoryItemQueries InventoryItemQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _inventoryItemQueries = InventoryItemQueries;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryItemQueries.GetById(id, cancellationToken));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryItemQueries.GetAll(param, cancellationToken));
        }

        [HttpGet("get-all-tree")]
        public async Task<IActionResult> GetAllTree([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _inventoryItemQueries.GetAllTree(param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand request, CancellationToken cancellationToken)
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
