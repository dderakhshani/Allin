using AutoMapper;

namespace Allin.Common.Data
{
    public abstract class QueryBase<TDbContext> where TDbContext : BaseDbContext
    {
        protected TDbContext DbContext { get; private set; }
        protected IMapper Mapper { get; private set; }
        protected IConfigurationProvider MapperProvider
        {
            get
            {
                return Mapper.ConfigurationProvider;
            }
        }

        protected QueryBase(TDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
    }
}
