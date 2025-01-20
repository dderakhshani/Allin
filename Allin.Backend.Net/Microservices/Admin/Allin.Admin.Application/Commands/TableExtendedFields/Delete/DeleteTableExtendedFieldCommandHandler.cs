using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteTableExtendedFieldCommandHandler : AdminCommandHandler<DeleteTableExtendedFieldCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteTableExtendedFieldCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteTableExtendedFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.TableExtendedFields.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            DbContext.TableExtendedFields.Remove(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
