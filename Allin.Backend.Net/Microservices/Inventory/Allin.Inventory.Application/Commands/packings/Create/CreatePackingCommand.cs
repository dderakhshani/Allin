using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;
using MediatR;
namespace Allin.Inventory.Application.Commands.packings.Create
{
    public class CreatePackingCommand : IRequest<bool>, IMapFrom<Packing, CreatePackingCommand>
    {
        public int LevelCode { get; set; }
        public string Title { get; set; }
        public double ConversionFactor { get; set; }
        public long MeasureUnitBaseId { get; set; }

    }


}
