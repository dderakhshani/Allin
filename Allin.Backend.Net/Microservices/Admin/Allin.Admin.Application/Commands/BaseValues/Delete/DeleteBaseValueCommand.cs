using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBaseValueCommand : IRequest<bool>
    {
        public DeleteBaseValueCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
