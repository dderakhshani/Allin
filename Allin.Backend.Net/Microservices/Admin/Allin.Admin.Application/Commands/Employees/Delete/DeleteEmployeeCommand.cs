using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public DeleteEmployeeCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
