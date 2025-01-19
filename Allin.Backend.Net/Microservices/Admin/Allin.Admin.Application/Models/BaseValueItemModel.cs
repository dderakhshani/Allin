using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class BaseValueItemModel : AdminBaseModel, IMapFrom<BaseValueItem, BaseValueItemModel>
    {
        public long BaseValueId { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }

        // extra properties
        public string BaseValueUniqueName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaseValueItem, BaseValueItemModel>()
                    .ForMember(dest => dest.BaseValueUniqueName, opt => opt.MapFrom(src => src.BaseValue.UniqueName))
                   ;
        }

    }
}
