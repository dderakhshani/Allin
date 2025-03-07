
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
            builder.HasOne(d => d.ContainerPacking).WithMany(p => p.PackingArrangementContainerPackings)
                .HasForeignKey(d => d.ContainerPackingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackingArrangements_Packings1");

            builder.HasOne(d => d.Packing).WithMany(p => p.PackingArrangementPackings)
                .HasForeignKey(d => d.PackingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackingArrangements_Packings");
            base.Configure(builder);
        }
    }
}
