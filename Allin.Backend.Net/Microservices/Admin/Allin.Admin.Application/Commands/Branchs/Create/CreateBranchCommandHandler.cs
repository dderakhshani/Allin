using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateBranchCommandHandler : AdminCommandHandler<CreateBranchCommand, bool>
    {
        public CreateBranchCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = Mapper.Map<Branch>(request);

            DbContext.Branchs.Add(branch);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
