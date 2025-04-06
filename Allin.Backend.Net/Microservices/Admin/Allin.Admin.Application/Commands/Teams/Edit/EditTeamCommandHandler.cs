using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditTeamCommandHandler : AdminCommandHandler<EditTeamCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditTeamCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditTeamCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Teams.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, entity);

            DbContext.Teams.Update(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
