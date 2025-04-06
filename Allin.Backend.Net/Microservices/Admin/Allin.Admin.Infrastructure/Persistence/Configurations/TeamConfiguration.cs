using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class TeamConfiguration : AdminTypeConfiguration<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams", "Organization");

            base.Configure(builder);
        }
    }


}
