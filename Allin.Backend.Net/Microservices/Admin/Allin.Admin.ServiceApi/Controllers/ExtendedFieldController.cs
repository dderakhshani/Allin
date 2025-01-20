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
    public class ExtendedFieldController : AuthorizeApiControllerBase
    {
        private readonly ITableExtendedFieldQueries _tableExtendedFieldQueries;

        public ExtendedFieldController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, ITableExtendedFieldQueries tableExtendedFieldQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _tableExtendedFieldQueries = tableExtendedFieldQueries;
        }

        [HttpGet("{tablName}")]
        public async Task<IActionResult> Get(string tablName, CancellationToken cancellationToken)
        {
            return OkResult(await _tableExtendedFieldQueries.GetByTableName(tablName, cancellationToken));
        }

        [HttpGet("get-all/{tableName}")]
        public async Task<IActionResult> GetAll([FromRoute] string tableName, [FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return OkResult(await _tableExtendedFieldQueries.GetAll(tableName, param, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableExtendedFieldCommand request, CancellationToken cancellationToken)
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
            return await SendCommand(new DeleteTableExtendedFieldCommand(id), cancellationToken);
        }


        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] long id, CancellationToken cancellationToken)
        {
            return await SendCommand(new DeleteTableExtendedFieldItemCommand(id), cancellationToken);
        }

    }
}
