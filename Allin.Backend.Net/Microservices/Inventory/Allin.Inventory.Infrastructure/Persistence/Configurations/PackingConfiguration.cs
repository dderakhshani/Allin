
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class PackingConfiguration : InventoryTypeConfiguration<Packing>
    {
        public override void Configure(EntityTypeBuilder<Packing> builder)
        {
            builder.ToTable("Packings", "Inventory");

            base.Configure(builder);
        }
    }
}
