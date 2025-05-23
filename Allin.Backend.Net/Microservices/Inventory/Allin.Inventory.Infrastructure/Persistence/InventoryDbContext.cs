﻿using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Allin.Inventory.Infrastructure.Persistence
{
    public class InventoryDbContext : BaseDbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<BaseValue> BaseValues { get; set; }

        public virtual DbSet<BaseValueItem> BaseValueItems { get; set; }

        public virtual DbSet<InventoryCategory> InventoryCategories { get; set; }

        public virtual DbSet<InventoryCategoryAllowdMeasure> InventoryCategoryAllowdMeasures { get; set; }

        public virtual DbSet<InventoryCategoryProperty> InventoryCategoryProperties { get; set; }

        public virtual DbSet<InventoryCategoryPropertyItem> InventoryCategoryPropertyItems { get; set; }
        public virtual DbSet<InventoryCategoryPropertyRange> InventoryCategoryPropertyRanges { get; set; }

        public virtual DbSet<InventoryItem> InventoryItems { get; set; }

        public virtual DbSet<InventoryItemAllowdMeasure> InventoryItemAllowdMeasures { get; set; }

        public virtual DbSet<InventoryItemType> InventoryItemTypes { get; set; }

        public virtual DbSet<InventoryPropertyValue> InventoryPropertyValues { get; set; }

        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }
        public virtual DbSet<Packing> Packings { get; set; }
        public virtual DbSet<PackingArrangement> PackingArrangements { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }


    }
}
