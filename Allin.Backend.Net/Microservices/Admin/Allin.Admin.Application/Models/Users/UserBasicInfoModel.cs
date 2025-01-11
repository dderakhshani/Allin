using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class BriefUserModel : AdminBaseModel, IMapFrom<User, BriefUserModel>
    {
        public string Username { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int FailedCount { get; set; }
        public DateTime? LastOnlineTime { get; set; }


        // nested props
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, BriefUserModel>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.Person.FirstName))

                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.Person.LastName))

                    .ForMember(dest => dest.Ssn, opt => opt.MapFrom(src => src.Employee.Person.Ssn)).ReverseMap();
        }
    }
}
