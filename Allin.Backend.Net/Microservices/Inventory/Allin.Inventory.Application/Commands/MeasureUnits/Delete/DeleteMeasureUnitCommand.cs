using MediatR;

namespace Allin.Inventory.Application.Commands
{
    public class DeleteMeasureUnitCommand : IRequest<bool>
    {
        public DeleteMeasureUnitCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
