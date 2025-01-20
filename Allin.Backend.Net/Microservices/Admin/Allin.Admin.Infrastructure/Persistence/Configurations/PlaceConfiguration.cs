using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class PlaceConfiguration : AdminTypeConfiguration<Place>
    {
        public override void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places", "Organization");

            base.Configure(builder);
        }
    }


}
