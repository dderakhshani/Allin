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
    public partial class BaseValueConfiguration : IEntityTypeConfiguration<BaseValue>
    {
        public void Configure(EntityTypeBuilder<BaseValue> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_BaseValueTypes");

            entity.ToTable("BaseValues", "admin");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.UniqueName)
                .HasMaxLength(128)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<BaseValue> entity);
    }
}
