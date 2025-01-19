using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class BreifEmployeeModel : AdminBaseModel, IMapFrom<Employee, BreifEmployeeModel>
    {
        public string EmployeeCode { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public BriefPersonModel Person { get; set; }

        // Titles 
        public string ContractTypeBaseTitle { get; set; }
        public string DepartmentTitle { get; set; }
        public string PositionTitle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, BreifEmployeeModel>()
                    .ForMember(dest => dest.ContractTypeBaseTitle, opt => opt.MapFrom(src => src.ContractTypeBase.Title))

                    .ForMember(dest => dest.DepartmentTitle, opt => opt.MapFrom(src => src.DepartmentPosition.Department.Title))

                    .ForMember(dest => dest.PositionTitle, opt => opt.MapFrom(src => src.DepartmentPosition.Position.Title));

        }
    }
}
