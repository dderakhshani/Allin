using Allin.Common.Data;
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

        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<InventoryCategoryAllowdMeasure> InventoryCategoryAllowdMeasures { get; set; }
        public DbSet<InventoryCategoryProperty> InventoryCategoryProperties { get; set; }
        public DbSet<InventoryCategoryPropertyItem> InventoryCategoryPropertyItems { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryItemAllowdMeasure> InventoryItemAllowdMeasures { get; set; }
        public DbSet<InventoryItemType> InventoryItemTypes { get; set; }
        public DbSet<InventoryPropertyValue> InventoryPropertyValues { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }

    }
}
