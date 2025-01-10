using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeleteEmployeeCommandHandler : AdminCommandHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeleteEmployeeCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Employeies.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            using (DbContext.Database.BeginTransaction())
            {
                DbContext.Employeies.Remove(entity);

                var extendedFieldValues = await DbContext.TableExtendedFieldValues.Where(x => x.RecordId == entity.Id).ToListAsync(cancellationToken);

                DbContext.TableExtendedFieldValues.RemoveRange(extendedFieldValues);

                await DbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
