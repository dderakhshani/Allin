using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeletePlaceCommandHandler : AdminCommandHandler<DeletePlaceCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeletePlaceCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Places.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.Places.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
