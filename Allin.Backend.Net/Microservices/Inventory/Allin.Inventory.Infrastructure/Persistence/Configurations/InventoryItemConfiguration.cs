using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryItemConfiguration : InventoryTypeConfiguration<InventoryItem>
    {
        public override void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.ToTable("InventoryItems", "Inventory");

            base.Configure(builder);
        }
    }
}
