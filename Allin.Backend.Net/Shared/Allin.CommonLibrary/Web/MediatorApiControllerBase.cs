
using Allin.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NanoidDotNet;

namespace Allin.Common.Web
{
    public class MediatorApiControllerBase : ApiControllerBase
    {
        protected readonly IUserAccessor _userAccessor;
        protected readonly IWebHostEnvironment _currentEnvironment;
        private readonly IMediator _mediator;

        public MediatorApiControllerBase(
           IMediator mediator,
           IUserAccessor userAccessor,
           IWebHostEnvironment currentEnvironment)
        {
            _userAccessor = userAccessor;
            _currentEnvironment = currentEnvironment;
            _mediator = mediator;
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

        public virtual async Task<IActionResult> SendQuery<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken)
        {
            return Ok(await Send(query, cancellationToken));
        }

        public virtual async Task<IActionResult> SendCommand<TResponse>(IRequest<TResponse> command,
           CancellationToken cancellationToken)
        {
            return Ok(await Send(command, cancellationToken));
        }

        public virtual async Task<GeneralApiResult> Send<TResponse>(IRequest<TResponse> query,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(query, cancellationToken);
                return GeneralApiResult.Ok(Nanoid.Generate(size: 8), result);
            }
            catch (AllinException ex)
            {
                var logger = HttpContext.RequestServices.GetRequiredService<ILogger<AuthorizeApiControllerBase>>();
                logger.LogError(ex, ex.Message);

                var errMsg = $"{ex.ErrorMessage}.";

                if (!string.IsNullOrWhiteSpace(ex.Tag))
                {
                    errMsg += $" ({ex.Tag})";
                }

                return GeneralApiResult.Fail(Nanoid.Generate(size: 8), errMsg);
            }

            catch (Exception ex)
            {
                var logger = HttpContext.RequestServices.GetRequiredService<ILogger<AuthorizeApiControllerBase>>();
                logger.LogError(ex, ex.Message);

                return GeneralApiResult.Fail(Nanoid.Generate(size: 8), ex.Message);
            }
        }
    }
}
