
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryCategoryPropertyItemConfiguration : InventoryTypeConfiguration<InventoryCategoryPropertyItem>
    {
        public override void Configure(EntityTypeBuilder<InventoryCategoryPropertyItem> builder)
        {
            builder.ToTable("InventoryCategoryPropertyItems", "Inventory");

            base.Configure(builder);
        }
    }
}
