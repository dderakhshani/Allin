
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryItemAllowdMeasureConfiguration : InventoryTypeConfiguration<InventoryItemAllowdMeasure>
    {
        public override void Configure(EntityTypeBuilder<InventoryItemAllowdMeasure> builder)
        {
            builder.ToTable("InventoryItemAllowdMeasures", "Inventory");

            base.Configure(builder);
        }
    }
}
