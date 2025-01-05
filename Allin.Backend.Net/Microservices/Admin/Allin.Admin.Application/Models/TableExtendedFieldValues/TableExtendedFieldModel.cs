using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class TableExtendedFieldValueModel : AdminBaseModel, IMapFrom<TableExtendedFieldValue, TableExtendedFieldValueModel>
    {
        public long RecordId { get; set; }
        public long TableExtendedFieldId { get; set; }
        public string Value { get; set; }
        public string ValueFieldItemId { get; set; }
    }
}
