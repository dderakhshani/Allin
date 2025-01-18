using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateBaseValueCommand : IRequest<bool>, IMapFrom<BaseValue, CreateBaseValueCommand>
    {
        public long BaseValueTypeId { get; set; }
        public long? ParentId { get; set; }
        public string BaseValueTitle { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}