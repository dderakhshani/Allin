using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteRoleCommandHandler : AdminCommandHandler<DeleteRoleCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteRoleCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await DbContext.Roles.Include(x => x.RolePermissions).FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.Roles.Remove(role);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
