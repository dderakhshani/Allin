using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class UserDeniedPermissionConfiguration : AdminTypeConfiguration<UserDeniedPermission>
    {
        public override void Configure(EntityTypeBuilder<UserDeniedPermission> builder)
        {
            builder.ToTable("UserDeniedPermissions", "Admin");

            base.Configure(builder);
        }
    }
}
