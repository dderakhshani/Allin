using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeletePositionCommand : IRequest<bool>
    {
        public DeletePositionCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
