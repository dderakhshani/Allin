using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditTableExtendedFieldCommand : IRequest<bool>, IMapFrom<TableExtendedField, EditTableExtendedFieldCommand>
    {
        public long Id { get; set; }
        public string FieldName { get; set; }
        public string UniqueName { get; set; }
        public string Description { get; set; }
        public FieldTypeEnums FieldTypeEnum { get; set; }
        public UicontrolEnums UicontrolEnum { get; set; }
        public int OrderIndex { get; set; }

        public IEnumerable<TableFieldItemArg> Items { get; set; }
    }
}
