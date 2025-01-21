using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreatePlaceCommand : IRequest<bool>, IMapFrom<Place, CreatePlaceCommand>
    {
        public long? ParentId { get; set; }
        public long? PlaceBaseId { get; set; }
        public string PlaceTitle { get; set; } = null!;
    }
}