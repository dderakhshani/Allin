using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Allin.Common.Web
{
    [Authorize]
    public abstract class AuthorizeApiControllerBase : MediatorApiControllerBase
    {
        protected AuthorizeApiControllerBase(IMediator mediator, IUserAccessor userAccessor, IWebHostEnvironment currentEnvironment) : base(mediator, userAccessor, currentEnvironment)
        {
        }
    }
}
