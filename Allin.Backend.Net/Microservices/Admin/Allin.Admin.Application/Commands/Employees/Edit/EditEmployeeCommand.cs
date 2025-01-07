using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditEmployeeCommand : IRequest<bool>, IMapFrom<Employee, EditEmployeeCommand>
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long? DepartmentPositionId { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public long ContractTypeBaseId { get; set; }
        public bool Floating { get; set; }
        public DateTime? LeaveDate { get; set; }
        public IEnumerable<ExtendedFieldArg> ExtendedFieldValues { get; set; }
    }
}
