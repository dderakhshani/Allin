using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditRoleCommand : IRequest<bool>, IMapFrom<Role, CreateRoleCommand>
    {
        public required long Id { get; set; }
        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }
    }
}
