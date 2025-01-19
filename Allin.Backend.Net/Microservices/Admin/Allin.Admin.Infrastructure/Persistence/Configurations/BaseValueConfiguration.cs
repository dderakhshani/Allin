using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class BaseValueConfiguration : AdminTypeConfiguration<BaseValue>
    {
        public override void Configure(EntityTypeBuilder<BaseValue> builder)
        {
            builder.ToTable("BaseValues", "Admin");

            base.Configure(builder);
        }
    }


}
