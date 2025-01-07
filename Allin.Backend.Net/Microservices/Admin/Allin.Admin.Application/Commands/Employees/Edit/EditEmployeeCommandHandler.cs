using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditEmployeeCommandHandler : AdminCommandHandler<EditEmployeeCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditEmployeeCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Employee>(request);

            var extendedFieldValues = Mapper.Map<IEnumerable<TableExtendedFieldValue>>(request.ExtendedFieldValues);

            using (DbContext.Database.BeginTransaction())
            {
                var existExtendedFieldValues = await DbContext.TableExtendedFieldValues.Where(x => x.RecordId == request.Id).ToListAsync();

                DbContext.TableExtendedFieldValues.RemoveRange(existExtendedFieldValues);

                DbContext.Employeies.Update(entity);

                foreach (var item in extendedFieldValues)
                    item.RecordId = entity.Id;

                DbContext.TableExtendedFieldValues.AddRange(extendedFieldValues);
                await DbContext.SaveChangesAsync(cancellationToken);

                DbContext.Database.CommitTransaction();
            }

            return true;
        }
    }
}
