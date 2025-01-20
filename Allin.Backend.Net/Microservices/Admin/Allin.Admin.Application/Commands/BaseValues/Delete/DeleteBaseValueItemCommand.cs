using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBaseValueItemCommand : IRequest<bool>
    {
        public DeleteBaseValueItemCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
