using Allin.Admin.Infrastructure.Persistence.Entities;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Allin.Admin.Infrastructure.Persistence
{
    public class AdminDbContext : BaseDbContext
    {
        public AdminDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
