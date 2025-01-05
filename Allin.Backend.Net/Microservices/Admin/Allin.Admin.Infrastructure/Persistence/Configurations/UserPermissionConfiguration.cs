using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class UserPermissionConfiguration : AdminTypeConfiguration<UserPermission>
    {
        public override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermissions", "Admin");

            base.Configure(builder);
        }
    }
}
