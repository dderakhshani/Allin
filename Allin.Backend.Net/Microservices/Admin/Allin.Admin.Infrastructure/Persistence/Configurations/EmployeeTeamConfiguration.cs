using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class EmployeeTeamConfiguration : AdminTypeConfiguration<EmployeeTeam>
    {
        public override void Configure(EntityTypeBuilder<EmployeeTeam> builder)
        {
            builder.ToTable("EmployeeTeams", "Organization");

            base.Configure(builder);
        }
    }


}
