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

        //[HttpGet("get-time")]
        //public async Task<IActionResult> GetAllBaseValues(CancellationToken cancellationToken)
        //{
        //    return OkResult(await _baseValueQueries.GetAll(cancellationToken));
        //}
    }
}
