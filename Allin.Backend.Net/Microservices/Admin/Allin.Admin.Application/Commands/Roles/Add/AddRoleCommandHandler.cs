using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class AddRoleCommandHandler : AdminCommandHandler<AddRoleCommand, bool>
    {
        public AddRoleCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var role = Mapper.Map<Role>(request);
            DbContext.Roles.Add(role);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
