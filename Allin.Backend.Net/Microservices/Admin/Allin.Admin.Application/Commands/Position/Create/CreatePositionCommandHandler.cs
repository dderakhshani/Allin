using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using AutoMapper;
using System.Data;

namespace Allin.Admin.Application.Commands
{
    public class CreatePositionCommandHandler : AdminCommandHandler<CreatePositionCommand, bool>
    {
        public CreatePositionCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Position>(request);

            entity.Hierarchy = await DbContext.Positions.GetHierarchyIdAsync(request.ParentId);

            DbContext.Positions.Add(entity);

            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
