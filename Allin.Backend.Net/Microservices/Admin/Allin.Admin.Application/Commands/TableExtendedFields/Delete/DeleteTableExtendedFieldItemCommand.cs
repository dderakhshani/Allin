using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteTableExtendedFieldItemCommand : IRequest<bool>
    {
        public DeleteTableExtendedFieldItemCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
