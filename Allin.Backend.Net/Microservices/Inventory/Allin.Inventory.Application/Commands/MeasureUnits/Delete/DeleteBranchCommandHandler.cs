using Allin.Common.Validations;
using Allin.Inventory.Application.Common;
using Allin.Inventory.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Inventory.Application.Commands
{
    public class DeleteMeasureUnitCommandHandler : InventoryCommandHandler<DeleteMeasureUnitCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteMeasureUnitCommandHandler(InventoryDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            var Branch = await DbContext.MeasureUnits.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.MeasureUnits.Remove(Branch);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
