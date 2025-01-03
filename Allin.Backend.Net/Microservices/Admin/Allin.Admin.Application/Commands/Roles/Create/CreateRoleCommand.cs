using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateRoleCommand : IRequest<bool>, IMapFrom<Role, CreateRoleCommand>
    {
        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }
    }
}
