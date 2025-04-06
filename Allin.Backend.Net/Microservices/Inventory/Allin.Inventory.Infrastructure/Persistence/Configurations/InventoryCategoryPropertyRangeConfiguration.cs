
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryCategoryPropertyRangeConfiguration : InventoryTypeConfiguration<InventoryCategoryPropertyRange>
    {
        public override void Configure(EntityTypeBuilder<InventoryCategoryPropertyRange> builder)
        {
            builder.ToTable("InventoryCategoryPropertyRanges", "Inventory");

            base.Configure(builder);
        }
    }
}
