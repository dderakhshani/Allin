
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryCategoryPropertyConfiguration : InventoryTypeConfiguration<InventoryCategoryProperty>
    {
        public override void Configure(EntityTypeBuilder<InventoryCategoryProperty> builder)
        {
            builder.ToTable("InventoryCategoryProperties", "Inventory");

            base.Configure(builder);
        }

    }
}
