using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateBaseValueCommandHandler : AdminCommandHandler<CreateBaseValueCommand, bool>
    {
        public CreateBaseValueCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateBaseValueCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<BaseValue>(request);

            DbContext.BaseValues.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
