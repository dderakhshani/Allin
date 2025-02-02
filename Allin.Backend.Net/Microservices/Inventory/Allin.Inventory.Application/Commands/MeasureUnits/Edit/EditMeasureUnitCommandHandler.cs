using Allin.Common.Validations;
using Allin.Inventory.Application.Common;
using Allin.Inventory.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Inventory.Application.Commands
{
    public class EditMeasureUnitCommandHandler : InventoryCommandHandler<EditMeasureUnitCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditMeasureUnitCommandHandler(InventoryDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.MeasureUnits.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
