using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditUserCommandHandler : AdminCommandHandler<EditUserCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        private IPasswordHasher<User> _passwordHasher;

        public EditUserCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider, IPasswordHasher<User> passwordHasher) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
            _passwordHasher = passwordHasher;
        }

        public override async Task<bool> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Users.Include(x => x.UserDeniedPermissions).Include(x => x.UserRoles).FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            entity.Username = request.Username;
            entity.IsBlocked = request.IsBlocked;
            entity.BlockedReasonBaseId = request.BlockedReasonBaseId;
            entity.EmployeeId = request.EmployeeId;
            entity.PasswordExpiryDate = request.PasswordExpiryDate;

            if (!string.IsNullOrEmpty(request.Password))
                entity.Password = _passwordHasher.HashPassword(entity, request.Password);

            entity.UserRoles = request.RoleIds.Select(x => new UserRole
            {
                RoleId = x
            }).ToList();

            entity.UserDeniedPermissions = request.DeniedPermissionIds.Select(x => new UserDeniedPermission
            {
                PermissionId = x
            }).ToList();

            DbContext.Users.Update(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
