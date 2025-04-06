
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class WarehouseConfiguration : InventoryTypeConfiguration<Warehouse>
    {
        public override void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouses", "Wms");

            base.Configure(builder);
        }
    }
}
