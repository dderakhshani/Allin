using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditPersonCommandHandler : AdminCommandHandler<EditPersonCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditPersonCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.Persons.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, entity);

            var extendedFieldValues = Mapper.Map<IEnumerable<TableExtendedFieldValue>>(request.ExtendedFieldValues);

            using (DbContext.Database.BeginTransaction())
            {
                var existExtendedFieldValues = await DbContext.TableExtendedFieldValues.Where(x => x.RecordId == request.Id).ToListAsync();

                DbContext.TableExtendedFieldValues.RemoveRange(existExtendedFieldValues);

                var existAddresses = await DbContext.PersonAddresses.Where(x => x.PersonId == entity.Id).ToListAsync();

                DbContext.PersonAddresses.RemoveRange(existAddresses);

                DbContext.Persons.Update(entity);

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
