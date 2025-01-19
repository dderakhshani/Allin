using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class AddBaseValueItemCommandHandler : AdminCommandHandler<AddBaseValueItemCommand, bool>
    {
        public AddBaseValueItemCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(AddBaseValueItemCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<BaseValueItem>(request);

            DbContext.BaseValueItems.Add(entity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
