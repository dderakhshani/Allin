
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryCategoryAllowdMeasureConfiguration : InventoryTypeConfiguration<InventoryCategoryAllowdMeasure>
    {
        public override void Configure(EntityTypeBuilder<InventoryCategoryAllowdMeasure> builder)
        {
            builder.ToTable("InventoryCategoryAllowdMeasures", "Inventory");

            base.Configure(builder);
        }

    }
}
