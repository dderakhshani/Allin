using Allin.Common.Utilities;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;
using MediatR;

namespace Allin.Inventory.Application.Common
{
    public abstract class InventoryCommandHandler<TRequest, TResponse> : BaseCommandHandler<TRequest, TResponse, InventoryDbContext>
           where TRequest : IRequest<TResponse>
    {
        protected InventoryCommandHandler(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }

}
