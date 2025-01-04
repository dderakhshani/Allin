using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;

namespace Allin.Admin.Application.Models
{
    public class TableExtendedFieldItemModel : AdminBaseModel, IMapFrom<TableExtendedFieldItem, TableExtendedFieldItemModel>
    {
        public long TableExtendedFieldsId { get; set; }
        public long ParentId { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Value { get; set; }
        public int OrderIndex { get; set; }
    }
}
