using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditBranchCommandHandler : AdminCommandHandler<EditBranchCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditBranchCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await DbContext.Branchs.FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, branch);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
