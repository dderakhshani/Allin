using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class AddBaseValueCommand : IRequest<bool>, IMapFrom<BaseValueItem, AddBaseValueCommand>
    {
        public long BaseValueTypeId { get; set; }
        public long? ParentId { get; set; }
        public required string Title { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string? Description { get; set; }
    }
}