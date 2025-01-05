using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class DepartmentPositionConfiguration : AdminTypeConfiguration<DepartmentPosition>
    {
        public override void Configure(EntityTypeBuilder<DepartmentPosition> builder)
        {
            builder.ToTable("DepartmentPositions", "Organization");

            base.Configure(builder);
        }
    }
}
