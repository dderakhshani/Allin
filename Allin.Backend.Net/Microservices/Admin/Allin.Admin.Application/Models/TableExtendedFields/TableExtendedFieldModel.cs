using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class TableExtendedFieldModel : AdminBaseModel, IMapFrom<TableExtendedField, TableExtendedFieldModel>
    {
        public long? ParentId { get; set; }
        public string UniqueName { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }

        public FieldTypeEnums FieldTypeEnum { get; set; }

        public UicontrolEnums UicontrolEnum { get; set; }
        public int OrderIndex { get; set; }

        public IEnumerable<TableExtendedFieldItemModel> TableExtendedFieldItems { get; set; }
    }
}
