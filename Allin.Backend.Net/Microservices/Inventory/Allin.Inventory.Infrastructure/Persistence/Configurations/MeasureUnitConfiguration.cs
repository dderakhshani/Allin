using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence.Configurations
{
    public class MeasureUnitConfiguration : InventoryTypeConfiguration<MeasureUnit>
    {
        public override void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.ToTable("MeasureUnits", "Inventory");

            base.Configure(builder);
        }
    }
}
