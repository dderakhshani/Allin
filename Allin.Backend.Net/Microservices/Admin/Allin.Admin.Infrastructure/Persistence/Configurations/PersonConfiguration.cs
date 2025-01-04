using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class PersonConfiguration : AdminTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "Organization");

            base.Configure(builder);
        }
    }

  
}
