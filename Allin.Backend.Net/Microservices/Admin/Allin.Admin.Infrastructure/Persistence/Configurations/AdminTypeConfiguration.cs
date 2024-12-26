using Allin.Admin.Infrastructure.Persistence.Entities;
using Allin.SharedCore.Configurations;

namespace Allin.Admin.Infrastructure.Persistence.Configurations
{
    public abstract class AdminTypeConfiguration<T> : BaseTypeConfiguration<T>
        where T : AdminBaseEntity
    {

    }
}
