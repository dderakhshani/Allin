using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class UserRoleConfiguration : AdminTypeConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", "Admin");

            base.Configure(builder);
        }
    }
}
