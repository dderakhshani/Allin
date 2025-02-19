
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryPropertyValueConfiguration : InventoryTypeConfiguration<InventoryPropertyValue>
    {
        public override void Configure(EntityTypeBuilder<InventoryPropertyValue> builder)
        {
            builder.ToTable("InventoryPropertyValues", "Inventory");

            base.Configure(builder);
        }
    }
}
