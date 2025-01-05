using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateTableExtendedFieldCommand : IRequest<bool>
    {
        public required string TableName { get; set; }
        public IEnumerable<TableFieldArg> Fields { get; set; }
    }

    public class TableFieldArg : IMapFrom<TableExtendedField, CreateTableExtendedFieldCommand>
    {
        public string FieldName { get; set; }
        public string UniqueName { get; set; }
        public string Description { get; set; }
        public FieldTypeEnums FieldTypeEnum { get; set; }
        public UicontrolEnums UicontrolEnum { get; set; }
        public int OrderIndex { get; set; }

        public IEnumerable<TableFieldItemArg> Items { get; set; }
    }

    public class TableFieldItemArg : IMapFrom<TableExtendedFieldItem, TableFieldItemArg>
    {
        public long ParentId { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Value { get; set; }
        public int OrderIndex { get; set; }
    }
}