
using Allin.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Gradient.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase( IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMediator Mediator
        {
            get
            {
                return _mediator;
            }
        }
    }

    [Authorize]
    public class AuthorizeApiControllerBase : ApiControllerBase
    {
        protected readonly IUserAccessor _userAccessor;
        protected readonly IWebHostEnvironment _currentEnvironment;

        public AuthorizeApiControllerBase(
            IMediator mediator,
           IUserAccessor userAccessor,
           IWebHostEnvironment currentEnvironment):base(mediator)
        {
            _userAccessor = userAccessor;
            _currentEnvironment = currentEnvironment;
        }

        public long CurrentUserId
        {
            get
            {
                return _userAccessor.GetId();
            }
        }

        public string? CurrentUserFullName
        {
            get
            {
                return _userAccessor.GetUserFullName();
            }
        }
    }
}
