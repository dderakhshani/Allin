using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public DeleteDepartmentCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
