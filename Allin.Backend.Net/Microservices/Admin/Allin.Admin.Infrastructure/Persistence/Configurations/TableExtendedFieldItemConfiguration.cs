using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class TableExtendedFieldItemConfiguration : AdminTypeConfiguration<TableExtendedFieldItem>
    {
        public override void Configure(EntityTypeBuilder<TableExtendedFieldItem> builder)
        {
            builder.ToTable("TableExtendedFieldItems", "Common");

            base.Configure(builder);
        }
    }


}
