using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class UserConfiguration : AdminTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ow
            base.Configure(builder);
        }
    }
}
