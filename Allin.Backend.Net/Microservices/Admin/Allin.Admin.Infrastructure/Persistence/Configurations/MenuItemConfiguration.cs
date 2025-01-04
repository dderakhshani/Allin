using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class MenuItemConfiguration : AdminTypeConfiguration<MenuItem>
    {
        public override void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems", "Admin");

            base.Configure(builder);
        }
    }


}
