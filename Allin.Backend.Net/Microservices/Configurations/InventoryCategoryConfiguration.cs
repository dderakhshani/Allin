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
    public partial class InventoryCategoryConfiguration : IEntityTypeConfiguration<InventoryCategory>
    {
        public void Configure(EntityTypeBuilder<InventoryCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__19093A0B6F66E4D6");

            entity.ToTable("InventoryCategories", "inventory");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ItemsTypeId).HasComment("Assets(Machines,...), Consumable, Salable Product");
            entity.Property(e => e.ModifiedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Inventory__Paren__267ABA7A");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<InventoryCategory> entity);
    }
}
