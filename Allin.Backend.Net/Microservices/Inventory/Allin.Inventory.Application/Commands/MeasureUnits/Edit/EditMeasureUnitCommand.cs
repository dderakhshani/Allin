using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;
using MediatR;

namespace Allin.Inventory.Application.Commands
{
    public class EditMeasureUnitCommand : IRequest<bool>, IMapFrom<MeasureUnit, EditMeasureUnitCommand>
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string? Title { get; set; }
    }
}
