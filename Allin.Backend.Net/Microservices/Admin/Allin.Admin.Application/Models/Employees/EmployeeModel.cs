using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class EmployeeModel : AdminBaseModel, IMapFrom<Employee, EmployeeModel>
    {
        public long PersonId { get; set; }
        public long DepartmentId { get; set; }
        public long PositionId { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public long ContractTypeBaseId { get; set; }
        public bool Floating { get; set; }
        public DateTime? LeaveDate { get; set; }
        public IEnumerable<TableExtendedFieldValueModel> ExtendedFieldValues { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeModel>()
                    .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentPosition.DepartmentId))

                    .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.DepartmentPosition.PositionId));

        }
    }
}
