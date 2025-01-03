using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateRoleCommandHandler : AdminCommandHandler<CreateRoleCommand, bool>
    {
        public CreateRoleCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = Mapper.Map<Role>(request);
            DbContext.Roles.Add(role);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
