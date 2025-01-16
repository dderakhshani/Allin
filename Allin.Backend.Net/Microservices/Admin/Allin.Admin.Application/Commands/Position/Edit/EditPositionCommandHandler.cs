using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Validations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Commands
{
    public class EditPositionCommandHandler : AdminCommandHandler<EditPositionCommand, bool>
    {
        private readonly IExceptionProvider _exceptionProvider;
        public EditPositionCommandHandler(AdminDbContext dbContext, IMapper mapper, IExceptionProvider exceptionProvider) : base(dbContext, mapper)
        {
            _exceptionProvider = exceptionProvider;
        }

        public override async Task<bool> Handle(EditPositionCommand request, CancellationToken cancellationToken)
        {
            var department = await DbContext.Departments.Include(x => x.DepartmentPositions).FirstAsync(x => x.Id == request.Id) ?? throw _exceptionProvider.RecordNotFoundValidationException();

            Mapper.Map(request, department);

            department.DepartmentPositions.Clear();
            department.DepartmentPositions = request.PositionIds.Select(x => new DepartmentPosition()
            {
                PositionId = x,
            }).ToList();

            await DbContext.SaveChangesAsync();

            return true;
        }
    }
}
