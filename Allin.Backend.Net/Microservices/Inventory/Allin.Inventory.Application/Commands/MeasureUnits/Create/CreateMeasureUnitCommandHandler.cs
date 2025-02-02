using Allin.Common.Data;
using Allin.Inventory.Application.Common;
using Allin.Inventory.Infrastructure;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Inventory.Application.Commands
{
    public class CreateMeasureUnitCommandHandler : InventoryCommandHandler<CreateMeasureUnitCommand, bool>
    {
        public CreateMeasureUnitCommandHandler(InventoryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<MeasureUnit>(request);

            entity.Hierarchy = await DbContext.MeasureUnits.GetHierarchyIdAsync(request.ParentId);

            DbContext.MeasureUnits.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
