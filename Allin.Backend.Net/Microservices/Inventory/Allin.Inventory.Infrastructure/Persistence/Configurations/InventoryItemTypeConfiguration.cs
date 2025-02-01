using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryItemTypeConfiguration : InventoryTypeConfiguration<InventoryItemType>
    {
        public override void Configure(EntityTypeBuilder<InventoryItemType> builder)
        {
            builder.ToTable("InventoryItemTypes", "Inventory");

            base.Configure(builder);
        }
    }
}
