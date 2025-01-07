using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Data;
using Allin.Common.Data.QueryHelpers;
using Allin.Common.Data.QueryHelpers.QueryResultMaker;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Application.Queries
{
    public class EmployeeQueries : QueryBase<AdminDbContext>, IEmployeeQueries
    {
        public EmployeeQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<EmployeeModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Employeies.AsNoTracking().ProjectTo<EmployeeModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<EmployeeModel> GetById(long id, CancellationToken cancellationToken)
        {
            var employee = Mapper.Map<EmployeeModel>(await DbContext.Employeies.AsNoTracking().Include(x => x.ContractTypeBase).Include(x => x.DepartmentPosition).FirstAsync(x => x.Id == id, cancellationToken));

            employee.ExtendedFieldValues = await DbContext.TableExtendedFieldValues.AsNoTracking().Where(x => x.RecordId == id).ProjectTo<TableExtendedFieldValueModel>(MapperProvider).ToListAsync(cancellationToken);

            return employee;
        }
    }
}
