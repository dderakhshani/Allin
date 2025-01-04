using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreateTableExtendedFieldCommandHandler : AdminCommandHandler<CreateTableExtendedFieldCommand, bool>
    {
        public CreateTableExtendedFieldCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateTableExtendedFieldCommand request, CancellationToken cancellationToken)
        {
            var tableExtendedFields = Mapper.Map<IEnumerable<TableExtendedField>>(request.Fields);

            foreach (var item in tableExtendedFields)
                item.TableName = request.TableName;

            DbContext.TableExtendedFields.AddRange(tableExtendedFields);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
