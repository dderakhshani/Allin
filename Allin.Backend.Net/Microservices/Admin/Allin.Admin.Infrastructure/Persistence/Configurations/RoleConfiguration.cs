﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class RoleConfiguration : AdminTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "Admin");

            //builder.Property(x => x.Mobiles).HasColumnName("MobilesStrJson").HasConversion(
            //    x => string.Join(",", x),
            //    x => x.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList()
            //);

            base.Configure(builder);
        }
    }
}
