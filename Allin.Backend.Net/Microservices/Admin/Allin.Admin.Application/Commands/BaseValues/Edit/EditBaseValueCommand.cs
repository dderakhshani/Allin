using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditBaseValueCommand : IRequest<bool>, IMapFrom<BaseValue, EditBaseValueCommand>
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? UniqueName { get; set; }
    }
}
