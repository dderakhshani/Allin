using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class BaseValueItemConfiguration : AdminTypeConfiguration<BaseValueItem>
    {
        public override void Configure(EntityTypeBuilder<BaseValueItem> builder)
        {
            builder.ToTable("BaseValueItems", "Admin");

            base.Configure(builder);
        }
    }


}
