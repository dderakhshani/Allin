using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class PersonConfiguration : AdminTypeConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "Organization");
            //builder.Property(x => x.Phones).HasJsonPropertyName()
            //string ttt = "dddd.fffff";
            //ttt.Replace("StrJson", "")

            builder.Property(x => x.Phones).HasColumnName("PhonesStrJson").HasConversion(
                x => JsonSerializer.Serialize(x, new JsonSerializerOptions() { }),
                x => JsonSerializer.Deserialize<IList<PhonesComplex>>(x, new JsonSerializerOptions { })
            );

            base.Configure(builder);
        }
    }


}
