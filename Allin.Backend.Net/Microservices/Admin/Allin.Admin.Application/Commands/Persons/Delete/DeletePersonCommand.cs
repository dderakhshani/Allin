using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public DeletePersonCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
