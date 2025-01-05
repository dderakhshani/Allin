using Allin.Admin.Application.Common;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using AutoMapper;
using System.Data;

namespace Allin.Admin.Application.Commands
{
    public class CreateDepartmentCommandHandler : AdminCommandHandler<CreateDepartmentCommand, bool>
    {
        public CreateDepartmentCommandHandler(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = Mapper.Map<Department>(request);

            department.DepartmentPositions = request.PositionIds.Select(x => new DepartmentPosition()
            {
                PositionId = x,
            }).ToList();

            department.Hierarchy = await DbContext.Departments.GetHierarchyIdAsync(request.ParentId);

            DbContext.Departments.Add(department);
            await DbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
