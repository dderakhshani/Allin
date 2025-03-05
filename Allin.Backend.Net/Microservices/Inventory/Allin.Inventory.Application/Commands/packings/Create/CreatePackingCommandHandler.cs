using Allin.Inventory.Application.Common;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Inventory.Application.Commands.packings.Create
{
    public class CreatePackingCommandHandler : InventoryCommandHandler<CreatePackingCommand, bool>
    {
        public CreatePackingCommandHandler(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreatePackingCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Packing>(request);

            DbContext.Packings.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
