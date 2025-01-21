using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeletePlaceCommand : IRequest<bool>
    {
        public DeletePlaceCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
