using Allin.SharedCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.SharedCore.Configurations
{
    public abstract class BaseTypeConfiguration<T> : IEntityTypeConfiguration<T>
          where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<DateTime>("CreatedAt")
                            .IsRequired()
                            .ValueGeneratedOnAddOrUpdate();

            builder.Property<DateTime>("ModifiedAt")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property<bool>("IsDeleted")
              .IsRequired();

        }
    }
}
