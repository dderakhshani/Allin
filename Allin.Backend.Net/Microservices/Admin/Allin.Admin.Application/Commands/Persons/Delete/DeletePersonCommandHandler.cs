using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class DeletePersonCommandHandler : AdminCommandHandler<DeletePersonCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public DeletePersonCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await DbContext.Persons.Include(x => x.PersonAddresses).FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            using (DbContext.Database.BeginTransaction())
            {
                DbContext.Persons.Remove(person);

                var extendedFieldValues = await DbContext.TableExtendedFieldValues.Where(x => x.RecordId == person.Id).ToListAsync(cancellationToken);

                DbContext.TableExtendedFieldValues.RemoveRange(extendedFieldValues);

                await DbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
