using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreatePlaceCommandHandler : AdminCommandHandler<CreatePlaceCommand, bool>
    {
        public CreatePlaceCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Place>(request);

            entity.Hierarchy = await DbContext.Places.GetHierarchyIdAsync(request.ParentId);

            DbContext.Places.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
