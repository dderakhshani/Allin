using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteTeamCommandHandler : AdminCommandHandler<DeleteTeamCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteTeamCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Teams.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.Teams.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
