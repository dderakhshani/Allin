using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateTeamCommandHandler : AdminCommandHandler<CreateTeamCommand, bool>
    {
        public CreateTeamCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Team>(request);

            entity.Hierarchy = await DbContext.Teams.GetHierarchyIdAsync(request.ParentId);

            DbContext.Teams.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
