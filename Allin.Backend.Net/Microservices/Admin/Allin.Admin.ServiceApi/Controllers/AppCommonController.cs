using Allin.Admin.Application.Queries;
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Admin.ServiceApi.Controllers
{
    [AllowAnonymous]
    public class AppCommonController : AuthorizeApiControllerBase
    {
        private readonly IBaseValueQueries _baseValueQueries;

        public AppCommonController(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment, IBaseValueQueries baseValueQueries) : base(mediator, userAccessor, currentEnvironment)
        {
            _baseValueQueries = baseValueQueries;
        }

        [HttpGet("get-all-base-values")]
        public async Task<IActionResult> GetAllBaseValues(CancellationToken cancellationToken)
        {
            return OkResult(await _baseValueQueries.GetAll(cancellationToken));
        }
    }
}
