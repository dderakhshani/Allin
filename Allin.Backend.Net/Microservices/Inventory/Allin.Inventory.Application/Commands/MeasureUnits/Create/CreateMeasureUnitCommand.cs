using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;
using MediatR;

namespace Allin.Inventory.Application.Commands
{
    public class CreateMeasureUnitCommand : IRequest<bool>, IMapFrom<MeasureUnit, CreateMeasureUnitCommand>
    {
        public long? ParentId { get; set; }
        public string? Title { get; set; }
    }
}