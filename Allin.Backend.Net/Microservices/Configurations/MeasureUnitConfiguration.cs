﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Allin.Inventory.Infrastructure;
using Allin.Inventory.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace Allin.Inventory.Infrastructure.Configurations
{
    public partial class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> entity)
        {
            entity.ToTable("MeasureUnits", "inventory");

            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MeasureUnit> entity);
    }
}
