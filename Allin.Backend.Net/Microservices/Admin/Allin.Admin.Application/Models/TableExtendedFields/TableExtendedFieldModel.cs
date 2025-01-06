using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;

namespace Allin.Admin.Application.Models
{
    public class TableExtendedFieldModel : AdminBaseModel, IMapFrom<TableExtendedField, TableExtendedFieldModel>
    {
        public long? ParentId { get; set; }
        public string UniqueName { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }

        public FieldTypeEnums FieldType { get; set; }

        public UicontrolEnums UiControl { get; set; }
        public int OrderIndex { get; set; }

        public IEnumerable<TableExtendedFieldItemModel> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TableExtendedField, TableExtendedFieldModel>()
                    .ForMember(dest => dest.FieldType, opt => opt.MapFrom(src => src.FieldTypeEnum))
                    .ForMember(dest => dest.UiControl, opt => opt.MapFrom(src => src.UicontrolEnum))
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.TableExtendedFieldItems))
                    .ReverseMap()
                    .IgnoreAllNonExisting();
        }
    }
}
