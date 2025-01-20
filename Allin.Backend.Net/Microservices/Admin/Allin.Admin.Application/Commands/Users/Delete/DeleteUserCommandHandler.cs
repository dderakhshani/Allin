using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteUserCommandHandler : AdminCommandHandler<DeleteUserCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteUserCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Users.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.Users.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
