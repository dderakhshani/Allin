using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditTeamCommand : IRequest<bool>, IMapFrom<Team, EditTeamCommand>
    {
        public required long Id { get; set; }
        public long? ParentId { get; set; }
        public long? PlaceBaseId { get; set; }
        public string PlaceTitle { get; set; } = null!;
    }
}
