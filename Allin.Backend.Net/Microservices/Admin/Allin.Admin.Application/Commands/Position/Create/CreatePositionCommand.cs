using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreatePositionCommand : IRequest<bool>, IMapFrom<Position, CreatePositionCommand>
    {
        public long? ParentId { get; set; }
        public string LevelCode { get; set; } = null!;
        public string Title { get; set; } = null!;

    }
}