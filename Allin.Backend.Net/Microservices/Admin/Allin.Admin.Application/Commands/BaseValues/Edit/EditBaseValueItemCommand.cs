using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditBaseValueItemCommand : IRequest<bool>, IMapFrom<BaseValueItem, EditBaseValueItemCommand>
    {
        public long Id { get; set; }
        public long BaseValueTypeId { get; set; }
        public long? ParentId { get; set; }
        public string BaseValueTitle { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
