using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditTableExtendedFieldCommandHandler : AdminCommandHandler<EditTableExtendedFieldCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditTableExtendedFieldCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditTableExtendedFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = await DbContext.TableExtendedFields.Include(x => x.TableExtendedFieldItems).FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, entity);

            Mapper.Map(request.Items, entity.TableExtendedFieldItems);

            DbContext.TableExtendedFields.Update(entity);

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
