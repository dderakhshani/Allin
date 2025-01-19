using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateBaseValuesCommand : IRequest<bool>
    {

        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }

        public IEnumerable<AddBaseValueCommand> Items { get; set; }
    }
}