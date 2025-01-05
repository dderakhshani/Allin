using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class TableExtendedFieldConfiguration : AdminTypeConfiguration<TableExtendedField>
    {
        public override void Configure(EntityTypeBuilder<TableExtendedField> builder)
        {
            builder.ToTable("TableExtendedFields", "Common");

            base.Configure(builder);
        }
    }


}
