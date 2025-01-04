using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateDepartmentCommand : IRequest<bool>, IMapFrom<Department, CreateDepartmentCommand>
    {
        public long? ParentId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public long BranchId { get; set; }
        public IEnumerable<long> PositionIds { get; set; }
    }
}