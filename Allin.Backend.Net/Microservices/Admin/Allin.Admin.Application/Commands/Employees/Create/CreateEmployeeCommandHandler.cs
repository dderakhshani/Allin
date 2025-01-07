using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateEmployeeCommandHandler : AdminCommandHandler<CreateEmployeeCommand, bool>
    {
        public CreateEmployeeCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<Employee>(request);

            var extendedFieldValues = Mapper.Map<IEnumerable<TableExtendedFieldValue>>(request.ExtendedFieldValues);

            using (DbContext.Database.BeginTransaction())
            {
                DbContext.Employeies.Add(entity);
                await DbContext.SaveChangesAsync(cancellationToken);

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
