
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class PlaceConfiguration : InventoryTypeConfiguration<Place>
    {
        public override void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places", "Organization");

            base.Configure(builder);
        }
    }
}
