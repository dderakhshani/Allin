using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class BaseValueTypeConfiguration : AdminTypeConfiguration<BaseValueType>
    {
        public override void Configure(EntityTypeBuilder<BaseValueType> builder)
        {
            builder.ToTable("BaseValueTypes", "Admin");

            base.Configure(builder);
        }
    }


}
