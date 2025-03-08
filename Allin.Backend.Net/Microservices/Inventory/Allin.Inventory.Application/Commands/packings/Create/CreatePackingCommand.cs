using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;
using MediatR;
namespace Allin.Inventory.Application.Commands.packings.Create
{
    public class CreatePackingCommand : IRequest<bool>, IMapFrom<Packing, CreatePackingCommand>
    {
        public int LevelCode { get; set; }
        public string Title { get; set; }
        public double ConversionFactor { get; set; }
        public long MeasureUnitBaseId { get; set; }
        public required IEnumerable<CreateArrangementCommand> Arrangements { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Packing, CreatePackingCommand>()
                  .ForMember(dest => dest.Arrangements, opt => opt.MapFrom(src => src.PackingArrangementPackings))
                  .ReverseMap();
        }
    }

    public class CreateArrangementCommand : IRequest<bool>, IMapFrom<PackingArrangement, CreateArrangementCommand>
    {
        public long? PackingId { get; set; }
        public double ConversionFactor { get; set; }
        public long ContainerPackingId { get; set; }

    }

}
