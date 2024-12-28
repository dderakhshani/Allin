using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands.Users.Add
{
    public class AddUserCommandHandler : AdminCommandHandler<AddUserCommand, bool>
    {
        public AddUserCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //_dbContext>
            // Add user logic goes here
            //DbContext.Users.Add

            return true;
        }

    }
}
