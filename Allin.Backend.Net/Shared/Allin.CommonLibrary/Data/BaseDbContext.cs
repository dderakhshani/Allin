﻿using Allin.Common.Configurations;
using Allin.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Allin.Common.Data;

public partial class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseTypeConfiguration<BaseEntity>).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task ExecuteAsUnitAsync(Func<Task> operationUnit, int unitTimeOut = 60 * 1000)
    {
        var strategy = this.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            using var transaction = await this.Database.BeginTransactionAsync();
            try
            {

                if (operationUnit().Wait(unitTimeOut))
                    transaction.Commit();
                else
                    throw new Exception(@"Unit operation timeout expired.  The timeout period elapsed prior to completion of the unit operation or the server is not responding.");

            }
            catch
            {
                transaction.Rollback();
                //Don't throw e or stack trace will be gone
                throw;// e;
            }
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;

            else if (entry.State == EntityState.Modified)
                entry.Property("ModifiedAt").CurrentValue = DateTime.Now;

            else if (entry.State == EntityState.Deleted)
                entry.Property("IsDeleted").CurrentValue = true;

        }
        return base.SaveChangesAsync(cancellationToken);
    }

    //TODO: This method may  be added later to logging or decide other type of logging
    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    //{
    //    List<(ILogger logger, EntityEntry entry)> loggerList =
    //        new List<(ILogger logger, EntityEntry entry)>();

    //    string companyConnectionStringName = _connectionStringProvider.GetConnectionStringName();
    //    var companyLogKey = SerilogConfigurator.CompanyLogKey(companyConnectionStringName);

    //    foreach (var entry in ChangeTracker.Entries())
    //    {
    //        if (entry.Entity is INotLoggable || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
    //        {
    //            continue;
    //        }


    //        var logger = Log.ForContext(companyLogKey, companyConnectionStringName)
    //            .ForContext("Operation", entry.State.ToString())
    //            .ForContext("Entity", $"{entry.Entity}")
    //            .ForContext("RequestMethod", _httpContext?.Request?.Method)
    //            .ForContext("RequestPath", _httpContext?.Request?.Path);


    //        if (_httpContext?.User?.Identity?.IsAuthenticated == true)
    //        {
    //            logger = logger.ForContext("UserName", _currentUserAccessor.GetUsername());
    //            logger = logger.ForContext("UserFullName", _currentUserAccessor.GetUserFullName());
    //            logger = logger.ForContext("UserId", _currentUserAccessor.GetId());
    //        }

    //        loggerList.Add((logger, entry));
    //    }

    //    var result = await base.SaveChangesAsync(cancellationToken);

    //    foreach (var e in loggerList)
    //    {
    //        var entityType = e.entry.Entity.GetType();
    //        var primaryKeys = this.Model.FindEntityType(entityType)!.FindPrimaryKey()!.Properties
    //            .Select(x => x.Name)
    //            .Select(keyName => entityType.GetProperty(keyName)!.GetValue(e.entry.Entity, null));

    //        var logger = e.logger.ForContext("Key", string.Join(',', primaryKeys));
    //        logger.Information(JsonConvert.SerializeObject(e.entry.Entity, Formatting.None,
    //            new JsonSerializerSettings
    //            {
    //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
    //                ContractResolver = new IgnoreVirtualContractResolver()
    //            }));

    //    }

    //    return result;

    //}

}


