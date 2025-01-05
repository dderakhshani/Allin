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
            var person = await DbContext.Persons.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, person);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
