using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class PersonAddressConfiguration : AdminTypeConfiguration<PersonAddress>
    {
        public override void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.ToTable("PersonAddresses", "Organization");

            base.Configure(builder);
        }
    }


}
