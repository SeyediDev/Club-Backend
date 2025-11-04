using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Club.AdminPanel.Web.Infrastructure;

/// <summary>
/// Interceptor که خودکار Cache را Invalidate می‌کند
/// وقتی داده‌ای در دیتابیس تغییر می‌کند (INSERT, UPDATE, DELETE)
/// </summary>
public class CacheInvalidationInterceptor : SaveChangesInterceptor
{
    private readonly IDatabaseCache _cache;
    private readonly ILogger<CacheInvalidationInterceptor> _logger;

    public CacheInvalidationInterceptor(
        IDatabaseCache cache,
        ILogger<CacheInvalidationInterceptor> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        InvalidateCache(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        InvalidateCache(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void InvalidateCache(DbContext? context)
    {
        if (context == null) return;

        var entries = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();

        foreach (var entry in entries)
        {
            var entityType = entry.Entity.GetType();
            var entityName = entityType.Name;

            // Invalidate کردن cache برای این entity
            if (TryGetEntityId(entry, out var entityId))
            {
                var cacheKey = $"{entityName}_{entityId}";
                _cache.Invalidate(cacheKey);
                _logger.LogDebug("Cache invalidated: {Key} (State: {State})", 
                    cacheKey, entry.State);
            }

            // Invalidate کردن لیست‌ها (مثلاً لیست محصولات)
            var listCacheKey = $"{entityName}_List";
            _cache.Invalidate(listCacheKey);
            
            // Invalidate کردن تمام cache های مرتبط با این entity
            _cache.InvalidateByPattern($"{entityName}_*");
        }
    }

    private bool TryGetEntityId(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, out object? entityId)
    {
        entityId = null;

        // پیدا کردن property که Id نام دارد
        var idProperty = entry.Properties
            .FirstOrDefault(p => p.Metadata.Name == "Id");

        if (idProperty != null)
        {
            entityId = idProperty.CurrentValue;
            return entityId != null;
        }

        return false;
    }
}

/// <summary>
/// Helper attribute برای مشخص کردن entity هایی که نباید cache شوند
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class NoCacheAttribute : Attribute
{
}

/// <summary>
/// Helper attribute برای مشخص کردن مدت زمان cache
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class CacheDurationAttribute : Attribute
{
    public int Minutes { get; set; }

    public CacheDurationAttribute(int minutes)
    {
        Minutes = minutes;
    }
}

