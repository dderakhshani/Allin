using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class TableExtendedFieldValueConfiguration : AdminTypeConfiguration<TableExtendedFieldValue>
    {
        public override void Configure(EntityTypeBuilder<TableExtendedFieldValue> builder)
        {
            builder.ToTable("TableExtendedFieldValues", "Common");

            base.Configure(builder);
        }
    }


}
