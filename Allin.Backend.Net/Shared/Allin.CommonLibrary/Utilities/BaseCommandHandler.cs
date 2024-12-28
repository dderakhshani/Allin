using Allin.Common.Data;
using AutoMapper;
using MediatR;

namespace Allin.Common.Utilities
{
    public abstract class BaseCommandHandler<TRequest, TResponse, TDbContext> : IRequestHandler<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TDbContext : BaseDbContext
    {
        protected TDbContext DbContext { get; private set; }
        protected IMapper Mapper { get; private set; }

        public BaseCommandHandler(
            TDbContext dbContext,
            IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

}
