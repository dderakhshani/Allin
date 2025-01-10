using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class BaseValueModel : AdminBaseModel, IMapFrom<BaseValue, BaseValueModel>
    {
        public long BaseValueTypeId { get; set; }
        public long? ParentId { get; set; }
        public string BaseValueTitle { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        // extra properties
        public string BaseValueTypeUniqueName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaseValue, BaseValueModel>()
                    .ForMember(dest => dest.BaseValueTypeUniqueName, opt => opt.MapFrom(src => src.BaseValueType.UniqueName))
                   ;
        }

    }
}
