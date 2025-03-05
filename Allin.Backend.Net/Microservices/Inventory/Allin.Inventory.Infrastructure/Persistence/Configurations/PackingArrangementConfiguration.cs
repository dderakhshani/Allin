
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class PackingArrangementConfiguration : InventoryTypeConfiguration<PackingArrangement>
    {
        public override void Configure(EntityTypeBuilder<PackingArrangement> builder)
        {
            builder.ToTable("PackingArrangements", "Inventory");

            base.Configure(builder);
        }
    }
}
