using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditRoleCommandHandler : AdminCommandHandler<EditRoleCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditRoleCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var newRole = Mapper.Map<Role>(request);

            DbContext.Entry(newRole).State = EntityState.Modified;
            DbContext.Roles.ExecuteUpdateAsync<Role>(newRole);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
