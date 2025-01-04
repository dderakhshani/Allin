using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class EditTableExtendedFieldCommand : IRequest<bool>, IMapFrom<TableExtendedField, EditTableExtendedFieldCommand>
    {

    }
}
