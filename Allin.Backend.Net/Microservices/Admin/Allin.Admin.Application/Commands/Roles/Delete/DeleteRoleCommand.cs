using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public DeleteRoleCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
