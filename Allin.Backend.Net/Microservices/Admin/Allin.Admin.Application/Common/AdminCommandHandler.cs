using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities;
using AutoMapper;
using MediatR;

namespace Allin.Admin.Application.Common
{
    public abstract class AdminCommandHandler<TRequest, TResponse> : BaseCommandHandler<TRequest, TResponse, AdminDbContext>
            where TRequest : IRequest<TResponse>
    {
        protected AdminCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
