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
            var role = await DbContext.Roles.Include(x => x.RolePermissions).FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, role);

            role.RolePermissions.Clear();
            role.RolePermissions = request.PermissionIds.Select(x => new RolePermission()
            {
                PermissionId = x,
            }).ToList();

            await DbContext.SaveChangesAsync();
            return true;

            //if (result == 0) throw _exceptionProvider.RecordNotFoundValidationException();
            //var result = await DbContext.Roles.ExecuteUpdateAsync(x =>
            //x.SetProperty(y => y.Title, z => request.Title)
            // .SetProperty(y => y.UniqueName, z => request.UniqueName)
            // .SetProperty(y => y.Description, z => request.Description)
            // .SetProperty(y => y.DepartmentId, z => request.DepartmentId)
            //, cancellationToken);
            //DbContext.Entry(newRole).State = EntityState.Modified;
            //await DbContext.Roles.ExecuteUpdateFromModelAsync<Role, EditRoleCommand>(request);
        }
    }
}
