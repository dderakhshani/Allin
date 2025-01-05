using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class PositionConfiguration : AdminTypeConfiguration<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions", "Organization");

            base.Configure(builder);
        }
    }
}
