using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
