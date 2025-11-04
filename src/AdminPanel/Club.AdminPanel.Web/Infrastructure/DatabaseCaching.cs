using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Club.AdminPanel.Web.Infrastructure;

/// <summary>
/// Extension Methods برای ثبت Database Caching در DI Container
/// </summary>
public static class DatabaseCachingServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseCaching(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var enableDatabaseCache = configuration.GetValue<bool>("DatabaseCache:Enabled", false);

        if (!enableDatabaseCache)
        {
            // کش غیرفعال است - استفاده از No-Op implementation
            services.AddSingleton<IDatabaseCache, NoOpDatabaseCache>();
            return services;
        }

        // کش فعال است
        services.AddMemoryCache();
        services.AddSingleton<IDatabaseCache, DatabaseCache>();
        
        // Interceptor برای Auto Invalidation
        services.AddScoped<CacheInvalidationInterceptor>();

        return services;
    }
}

/// <summary>
/// Version-Based Database Caching with automatic invalidation
/// مثل ETag برای HTTP، اما برای Database!
/// </summary>
public interface IDatabaseCache
{
    Task<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpiration = null) where T : class;

    void Invalidate(string key);
    void InvalidateByPattern(string pattern);
}

public class DatabaseCache : IDatabaseCache
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<DatabaseCache> _logger;
    private static readonly Dictionary<string, string> _versionCache = [];
    private static readonly object _lock = new();

    public DatabaseCache(IMemoryCache cache, ILogger<DatabaseCache> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpiration = null) where T : class
    {
        // 1. بررسی Cache
        var cacheKey = GenerateCacheKey<T>(key);
        
        if (_cache.TryGetValue(cacheKey, out CachedItem<T>? cachedItem))
        {
            _logger.LogDebug("Cache HIT for key: {Key}", key);
            return cachedItem!.Data;
        }

        _logger.LogDebug("Cache MISS for key: {Key}", key);

        // 2. خواندن از دیتابیس
        var data = await factory();
        if (data == null) return null;

        // 3. محاسبه Version (مثل ETag)
        var version = ComputeVersion(data);

        // 4. ذخیره در Cache
        var cacheOptions = new MemoryCacheEntryOptions();
        
        if (absoluteExpiration.HasValue)
            cacheOptions.SetAbsoluteExpiration(absoluteExpiration.Value);
        
        if (slidingExpiration.HasValue)
            cacheOptions.SetSlidingExpiration(slidingExpiration.Value);
        else
            cacheOptions.SetSlidingExpiration(TimeSpan.FromMinutes(30)); // Default

        // ثبت callback برای وقتی که cache منقضی می‌شود
        cacheOptions.RegisterPostEvictionCallback((key, value, reason, state) =>
        {
            _logger.LogDebug("Cache evicted: {Key}, Reason: {Reason}", key, reason);
        });

        var item = new CachedItem<T>
        {
            Data = data,
            Version = version,
            CachedAt = DateTime.UtcNow
        };

        _cache.Set(cacheKey, item, cacheOptions);

        // ذخیره version برای invalidation
        lock (_lock)
        {
            _versionCache[key] = version;
        }

        return data;
    }

    public void Invalidate(string key)
    {
        var cacheKey = $"DbCache_{key}";
        _cache.Remove(cacheKey);
        
        lock (_lock)
        {
            _versionCache.Remove(key);
        }
        
        _logger.LogInformation("Cache invalidated for key: {Key}", key);
    }

    public void InvalidateByPattern(string pattern)
    {
        // برای invalidate کردن چند cache به صورت یکجا
        // مثلاً: "Product_*" → تمام محصولات
        lock (_lock)
        {
            var keysToRemove = _versionCache.Keys
                .Where(k => k.StartsWith(pattern.Replace("*", "")))
                .ToList();

            foreach (var key in keysToRemove)
            {
                Invalidate(key);
            }
            _logger.LogInformation("Cache invalidated by pattern: {Pattern}, Count: {Count}",
                pattern, keysToRemove.Count);
        }
    }

    private string ComputeVersion<T>(T data)
    {
        // محاسبه "اثر انگشت" داده (مثل ETag)
        var json = JsonSerializer.Serialize(data);
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(json));
        return Convert.ToBase64String(hash);
    }

    private string GenerateCacheKey<T>(string key)
    {
        return $"DbCache_{typeof(T).Name}_{key}";
    }
}

public class CachedItem<T>
{
    public T Data { get; set; } = default!;
    public string Version { get; set; } = string.Empty;
    public DateTime CachedAt { get; set; }
}

/// <summary>
/// Extension Methods برای استفاده آسان
/// </summary>
/// <summary>
/// No-Op implementation برای غیرفعال کردن کش
/// هیچ کاری نمی‌کند، فقط مستقیماً query را اجرا می‌کند
/// </summary>
public class NoOpDatabaseCache : IDatabaseCache
{
    private readonly ILogger<NoOpDatabaseCache> _logger;

    public NoOpDatabaseCache(ILogger<NoOpDatabaseCache> logger)
    {
        _logger = logger;
    }

    public async Task<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpiration = null) where T : class
    {
        _logger.LogDebug("Database Cache is DISABLED. Executing query directly: {Key}", key);
        return await factory();
    }

    public void Invalidate(string key)
    {
        // No-op
    }

    public void InvalidateByPattern(string pattern)
    {
        // No-op
    }
}

public static class DatabaseCacheExtensions
{
    /// <summary>
    /// Cache کردن نتیجه query
    /// </summary>
    public static async Task<T?> CachedAsync<T>(
        this Task<T> query,
        IDatabaseCache cache,
        string key,
        TimeSpan? expiration = null) where T : class
    {
        return await cache.GetOrSetAsync(
            key,
            () => query,
            absoluteExpiration: expiration
        );
    }

    /// <summary>
    /// Cache کردن لیست
    /// </summary>
    public static async Task<List<T>> CachedListAsync<T>(
        this IQueryable<T> query,
        IDatabaseCache cache,
        string key,
        TimeSpan? expiration = null) where T : class
    {
        var result = await cache.GetOrSetAsync(
            key,
            async () => await query.ToListAsync(),
            absoluteExpiration: expiration
        );
        
        return result ?? [];
    }
}

