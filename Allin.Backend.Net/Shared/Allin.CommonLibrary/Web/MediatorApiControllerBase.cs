
using Allin.Common.Exceptions;
using Allin.Common.Validations;
using FluentValidation;
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

        protected virtual IActionResult OkResult(object result)
        {
            return GeneralApiResult.Ok(Nanoid.Generate(size: 8), result).MakeActionResult();
        }

        protected async Task<IActionResult> SendQuery<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken)
        {
            return (await Send(query, cancellationToken)).MakeActionResult();
        }

        protected async Task<IActionResult> SendCommand<TResponse>(IRequest<TResponse> command,
           CancellationToken cancellationToken)
        {
            return (await Send(command, cancellationToken)).MakeActionResult();
        }

        private async Task<GeneralApiResult> Send<TResponse>(IRequest<TResponse> query,
            CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(query, cancellationToken);
            return GeneralApiResult.Ok(Nanoid.Generate(size: 8), result);

        }
    }
}
