using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class AddRoleCommand : IRequest<bool>, IMapFrom<Role, AddRoleCommand>
    {
        public string? Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }
    }
}
