using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteTeamCommand : IRequest<bool>
    {
        public DeleteTeamCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
