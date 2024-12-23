using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;

namespace Allin.Common.Data;

public partial class BaseDbContext
{
    private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    private const int AbsoluteExpirationHours = 24;

    private string GetCacheKey<T>(DbSet<T> dbSet) where T : class
    {
        //TODO multiple connection string will be added later
        string connectionStringName = ""; //_connectionStringProvider.GetConnectionStringName();
        var entityName = dbSet.EntityType.ShortName();
        var key = $"{connectionStringName}-{entityName}";

        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(key));
        return Convert.ToBase64String(hash);
    }

    public IList<T> FromCache<T>(DbSet<T> dbSet, string? key = default, int expirationByHour = AbsoluteExpirationHours) where T : class
    {
        key ??= GetCacheKey(dbSet);

        var result = _cache.GetOrCreate(key, cache =>
        {
            cache.AbsoluteExpiration = DateTimeOffset.Now.AddHours(expirationByHour);
            return dbSet.AsNoTracking().ToList();
        }) ?? [];

        return result;
    }

    public async Task<IList<T>> FromCacheAsync<T>(DbSet<T> dbSet, string? key = default, int expirationByHour = AbsoluteExpirationHours, CancellationToken cancellationToken = default) where T : class
    {
        key ??= GetCacheKey(dbSet);


        var result = await _cache.GetOrCreateAsync(key, cache =>
        {
            cache.AbsoluteExpiration = DateTimeOffset.Now.AddHours(expirationByHour);
            return dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }) ?? [];

        return result;
    }

    public DbSet<T> RemoveCache<T>(DbSet<T> dbSet, string? key = default) where T : class
    {
        key ??= GetCacheKey(dbSet);

        _cache.Remove(key);

        return dbSet;
    }

    public void Clear()
    {
        _cache.Dispose();
        _cache = new MemoryCache(new MemoryCacheOptions());
    }
}
