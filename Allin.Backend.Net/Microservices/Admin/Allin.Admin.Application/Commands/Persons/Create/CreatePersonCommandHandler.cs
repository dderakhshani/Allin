using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using AutoMapper;

namespace Allin.Admin.Application.Commands
{
    public class CreatePersonCommandHandler : AdminCommandHandler<CreatePersonCommand, bool>
    {
        public CreatePersonCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = Mapper.Map<Person>(request);

            var extendedFieldValues = Mapper.Map<IEnumerable<TableExtendedFieldValue>>(request.ExtendedFieldValues);


            using (DbContext.Database.BeginTransaction())
            {
                DbContext.Persons.Add(person);
                await DbContext.SaveChangesAsync(cancellationToken);

                foreach (var item in extendedFieldValues)
                    item.RecordId = person.Id;

                DbContext.TableExtendedFieldValues.AddRange(extendedFieldValues);
                await DbContext.SaveChangesAsync(cancellationToken);

                DbContext.Database.CommitTransaction();
            }

            return true;
        }
    }
}
