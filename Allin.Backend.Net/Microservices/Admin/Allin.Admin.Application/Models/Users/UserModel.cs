using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class UserModel : AdminBaseModel, IMapFrom<User, UserModel>
    {
        public long EmployeeId { get; set; }
        public string Username { get; set; } = null!;
        public bool IsBlocked { get; set; }
        public long? BlockedReasonBaseId { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int FailedCount { get; set; }
        public DateTime? LastOnlineTime { get; set; }

        public IEnumerable<long> DeniedPermissionIds { get; set; }
        public IEnumerable<long> RoleIds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserModel>()
                  .ForMember(dest => dest.DeniedPermissionIds, opt => opt.MapFrom(src => src.UserDeniedPermissions.Select(x => x.PermissionId)))

                  .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(x => x.RoleId)))
                  .ReverseMap();
        }
    }
}
