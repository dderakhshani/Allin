using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditBaseValueItemCommandHandler : AdminCommandHandler<EditBaseValueItemCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditBaseValueItemCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditBaseValueItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.BaseValueItems.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
