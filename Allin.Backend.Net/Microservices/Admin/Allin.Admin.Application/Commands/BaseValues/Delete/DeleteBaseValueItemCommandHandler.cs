using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBaseValueItemCommandHandler : AdminCommandHandler<DeleteBaseValueItemCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteBaseValueItemCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteBaseValueItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.BaseValueItems.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.BaseValueItems.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
