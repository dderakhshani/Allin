using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditBranchCommand : IRequest<bool>, IMapFrom<Branch, EditBranchCommand>
    {
        public required long Id { get; set; }
        public required string Title { get; set; }
        public required string UniqueName { get; set; }
    }
}
