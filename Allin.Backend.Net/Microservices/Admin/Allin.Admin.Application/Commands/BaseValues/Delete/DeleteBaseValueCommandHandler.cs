using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteBaseValueCommandHandler : AdminCommandHandler<DeleteBaseValueCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteBaseValueCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteBaseValueCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.BaseValues.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.BaseValues.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
