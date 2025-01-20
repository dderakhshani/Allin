using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteTableExtendedFieldCommand : IRequest<bool>
    {
        public DeleteTableExtendedFieldCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
