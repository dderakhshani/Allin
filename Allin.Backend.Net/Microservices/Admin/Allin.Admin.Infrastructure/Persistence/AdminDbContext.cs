using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class AdminDbContext : BaseDbContext
    {
        public AdminDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BaseValue> BaseValues { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<BaseValueItem> BaseValueItems { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentPosition> DepartmentPositions { get; set; }
        public DbSet<Employee> Employeies { get; set; }
        public DbSet<Place> Locations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDeniedPermission> UserDeniedPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<TableExtendedField> TableExtendedFields { get; set; }
        public DbSet<TableExtendedFieldItem> TableExtendedFieldItems { get; set; }
        public DbSet<TableExtendedFieldValue> TableExtendedFieldValues { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<Place> Places { get; set; }


    }
}
