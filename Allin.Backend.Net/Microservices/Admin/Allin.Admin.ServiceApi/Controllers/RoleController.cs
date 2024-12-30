using Allin.Admin.Application.Commands;
using Allin.Admin.Application.Queries;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoidDotNet;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class RoleController : AuthorizeApiControllerBase
    {
        private readonly IRoleQueries _roleQueries;

        public RoleController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IRoleQueries roleQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _roleQueries = roleQueries;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParamModel param, CancellationToken cancellationToken)
        {
            return GeneralApiResult.Ok(Nanoid.Generate(size: 8), await _roleQueries.GetAll(param)).MakeActionResult();

            // return OkResult2(await _roleQueries.GetAll(), cancellationToken);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] GetRoleQuery request, CancellationToken cancellationToken)
        //{
        //    return await SendQuery(request, cancellationToken);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoleCommand request, CancellationToken cancellationToken)
        {
            return await SendCommand(request, cancellationToken);
        }
    }
}
