using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Allin.Admin.Application.Commands
{
    public class CreateUserCommandHandler : AdminCommandHandler<CreateUserCommand, bool>
    {
        private IPasswordHasher<User> _passwordHasher;
        public CreateUserCommandHandler(AdminDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher) : base(dbContext, mapper)
        {
            _passwordHasher = passwordHasher;
        }

        public override async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<User>(request);

            entity.UserRoles = request.RoleIds.Select(x => new UserRole
            {
                RoleId = x
            }).ToList();

            entity.UserDeniedPermissions = request.DeniedPermissionIds.Select(x => new UserDeniedPermission
            {
                PermissionId = x
            }).ToList();

            entity.Password = _passwordHasher.HashPassword(entity, request.Password);

            DbContext.Users.Add(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }

    }
}
