using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditPlaceCommand : IRequest<bool>, IMapFrom<Place, EditPlaceCommand>
    {
        public required long Id { get; set; }
        public long? ParentId { get; set; }
        public long? PlaceBaseId { get; set; }
        public string PlaceTitle { get; set; } = null!;
    }
}
