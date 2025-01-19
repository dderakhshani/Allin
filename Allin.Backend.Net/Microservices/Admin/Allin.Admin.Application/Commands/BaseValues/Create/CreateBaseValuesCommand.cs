using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateBaseValueCommand : IRequest<bool>
    {

        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }

        public required IEnumerable<AddBaseValueItemCommand> Items { get; set; }
    }
}