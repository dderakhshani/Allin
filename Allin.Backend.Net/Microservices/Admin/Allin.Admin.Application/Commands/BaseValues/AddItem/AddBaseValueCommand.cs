using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class AddBaseValueItemCommand : IRequest<bool>, IMapFrom<BaseValueItem, AddBaseValueItemCommand>
    {
        public long BaseValueId { get; set; }
        public long? ParentId { get; set; }
        public required string Title { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string? Description { get; set; }
    }
}