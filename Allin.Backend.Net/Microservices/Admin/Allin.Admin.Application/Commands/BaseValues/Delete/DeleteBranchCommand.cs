using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBranchCommand : IRequest<bool>
    {
        public DeleteBranchCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
