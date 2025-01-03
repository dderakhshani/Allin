using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateBranchCommand : IRequest<bool>, IMapFrom<Branch, CreateBranchCommand>
    {
        public required string Title { get; set; }
        public required string UniqueName { get; set; }
    }
}