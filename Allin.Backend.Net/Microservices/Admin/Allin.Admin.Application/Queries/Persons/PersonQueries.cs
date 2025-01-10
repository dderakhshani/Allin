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
    public class PersonQueries : QueryBase<AdminDbContext>, IPersonQueries
    {
        public PersonQueries(AdminDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedList<PersonModel>> GetAll(QueryParamModel param, CancellationToken cancellationToken)
        {
            return await DbContext.Persons.AsNoTracking().ProjectTo<PersonModel>(MapperProvider).ToPagedListAsync(param);
        }

        public async Task<PersonModel> GetById(long id, CancellationToken cancellationToken)
        {
            var person = Mapper.Map<PersonModel>(await DbContext.Persons.Include(x => x.PersonAddresses).AsNoTracking().FirstAsync(x => x.Id == id, cancellationToken));

            person.ExtendedFieldValues = await DbContext.TableExtendedFieldValues.AsNoTracking().Where(x => x.RecordId == id).ProjectTo<TableExtendedFieldValueModel>(MapperProvider).ToListAsync(cancellationToken);

            return person;
        }
    }
}
