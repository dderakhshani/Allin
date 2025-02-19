
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryCategoryConfiguration : InventoryTypeConfiguration<InventoryCategory>
    {
        public override void Configure(EntityTypeBuilder<InventoryCategory> builder)
        {
            builder.ToTable("InventoryCategories", "Inventory");

            base.Configure(builder);
        }
    }
}
