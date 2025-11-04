using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Club.AdminPanel.Web.Infrastructure;

/// <summary>
/// Version-Based Database Caching با Distributed Cache (Redis)
/// برای استفاده در Docker/Kubernetes/Multi-Server
/// </summary>
public class DistributedDatabaseCache : IDatabaseCache
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<DistributedDatabaseCache> _logger;
    private static readonly DistributedCacheEntryOptions DefaultOptions = new()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };

    public DistributedDatabaseCache(
        IDistributedCache cache,
        ILogger<DistributedDatabaseCache> logger)
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
        var cacheKey = GenerateCacheKey<T>(key);

        // 1. تلاش برای خواندن از Cache
        var cachedBytes = await _cache.GetAsync(cacheKey);
        
        if (cachedBytes != null)
        {
            try
            {
                var cachedItem = JsonSerializer.Deserialize<CachedItem<T>>(cachedBytes);
                if (cachedItem?.Data != null)
                {
                    _logger.LogDebug("Distributed Cache HIT for key: {Key}", key);
                    return cachedItem.Data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to deserialize cache for key: {Key}", key);
                await _cache.RemoveAsync(cacheKey);
            }
        }

        _logger.LogDebug("Distributed Cache MISS for key: {Key}", key);

        // 2. خواندن از دیتابیس
        var data = await factory();
        if (data == null) return null;

        // 3. محاسبه Version
        var version = ComputeVersion(data);

        // 4. ذخیره در Distributed Cache
        var cacheOptions = new DistributedCacheEntryOptions();
        
        if (absoluteExpiration.HasValue)
            cacheOptions.SetAbsoluteExpiration(absoluteExpiration.Value);
        
        if (slidingExpiration.HasValue)
            cacheOptions.SetSlidingExpiration(slidingExpiration.Value);
        else
            cacheOptions.SetSlidingExpiration(TimeSpan.FromMinutes(30));

        var item = new CachedItem<T>
        {
            Data = data,
            Version = version,
            CachedAt = DateTime.UtcNow
        };

        try
        {
            var serialized = JsonSerializer.SerializeToUtf8Bytes(item);
            await _cache.SetAsync(cacheKey, serialized, cacheOptions);
            _logger.LogDebug("Stored in Distributed Cache: {Key}, Size: {Size} bytes", 
                key, serialized.Length);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store in Distributed Cache: {Key}", key);
            // اگر Redis down باشد، داده را return می‌کنیم (graceful degradation)
        }

        return data;
    }

    public async void Invalidate(string key)
    {
        try
        {
            var cacheKey = $"DbCache_{key}";
            await _cache.RemoveAsync(cacheKey);
            _logger.LogInformation("Distributed Cache invalidated for key: {Key}", key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to invalidate Distributed Cache for key: {Key}", key);
        }
    }

    public void InvalidateByPattern(string pattern)
    {
        // Redis pattern matching برای invalidation
        _logger.LogWarning(
            "Pattern-based invalidation ({Pattern}) requires Redis SCAN command. " +
            "Consider implementing IConnectionMultiplexer for better performance.",
            pattern);
        
        // برای حالت ساده، فقط لاگ می‌کنیم
        // در production باید از Redis SCAN استفاده کنید
    }

    private string ComputeVersion<T>(T data)
    {
        var json = JsonSerializer.Serialize(data);
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(json));
        return Convert.ToBase64String(hash);
    }

    private string GenerateCacheKey<T>(string key)
    {
        return $"DbCache_{typeof(T).Name}_{key}";
    }
}

/// <summary>
/// Hybrid Cache: MemoryCache + DistributedCache (بهترین از هر دو دنیا!)
/// </summary>
public class HybridDatabaseCache : IDatabaseCache
{
    private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<HybridDatabaseCache> _logger;

    public HybridDatabaseCache(
        IMemoryCache memoryCache,
        IDistributedCache distributedCache,
        ILogger<HybridDatabaseCache> logger)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> factory,
        TimeSpan? absoluteExpiration = null,
        TimeSpan? slidingExpiration = null) where T : class
    {
        var cacheKey = $"DbCache_{typeof(T).Name}_{key}";

        // L1: بررسی Memory Cache (خیلی سریع - 0.01ms)
        if (_memoryCache.TryGetValue(cacheKey, out T? cachedData) && cachedData != null)
        {
            _logger.LogDebug("L1 Cache (Memory) HIT for key: {Key}", key);
            return cachedData;
        }

        // L2: بررسی Distributed Cache (سریع - 1-5ms)
        var cachedBytes = await _distributedCache.GetAsync(cacheKey);
        if (cachedBytes != null)
        {
            try
            {
                var cachedItem = JsonSerializer.Deserialize<CachedItem<T>>(cachedBytes);
                if (cachedItem?.Data != null)
                {
                    _logger.LogDebug("L2 Cache (Redis) HIT for key: {Key}", key);
                    
                    // ذخیره در L1 (Memory) برای دفعات بعد
                    var memOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5)); // کوتاه‌تر از Redis
                    _memoryCache.Set(cacheKey, cachedItem.Data, memOptions);
                    
                    return cachedItem.Data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to deserialize from L2 cache: {Key}", key);
            }
        }

        _logger.LogDebug("Cache MISS (L1+L2) for key: {Key}", key);

        // L3: خواندن از دیتابیس (کند - 50ms+)
        var data = await factory();
        if (data == null) return null;

        var version = ComputeVersion(data);
        var item = new CachedItem<T>
        {
            Data = data,
            Version = version,
            CachedAt = DateTime.UtcNow
        };

        // ذخیره در L1 (Memory)
        var memCacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(slidingExpiration ?? TimeSpan.FromMinutes(5));
        _memoryCache.Set(cacheKey, data, memCacheOptions);

        // ذخیره در L2 (Redis)
        try
        {
            var distCacheOptions = new DistributedCacheEntryOptions();
            if (absoluteExpiration.HasValue)
                distCacheOptions.SetAbsoluteExpiration(absoluteExpiration.Value);
            else if (slidingExpiration.HasValue)
                distCacheOptions.SetSlidingExpiration(slidingExpiration.Value);
            else
                distCacheOptions.SetSlidingExpiration(TimeSpan.FromMinutes(30));

            var serialized = JsonSerializer.SerializeToUtf8Bytes(item);
            await _distributedCache.SetAsync(cacheKey, serialized, distCacheOptions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to store in L2 cache: {Key}", key);
        }

        return data;
    }

    public async void Invalidate(string key)
    {
        var cacheKey = $"DbCache_{key}";
        
        // L1: حذف از Memory
        _memoryCache.Remove(cacheKey);
        
        // L2: حذف از Redis
        try
        {
            await _distributedCache.RemoveAsync(cacheKey);
            _logger.LogInformation("Hybrid Cache (L1+L2) invalidated for key: {Key}", key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to invalidate L2 cache for key: {Key}", key);
        }
    }

    public void InvalidateByPattern(string pattern)
    {
        _logger.LogWarning("Pattern invalidation not fully implemented in Hybrid cache: {Pattern}", pattern);
    }

    private string ComputeVersion<T>(T data)
    {
        var json = JsonSerializer.Serialize(data);
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(json));
        return Convert.ToBase64String(hash);
    }
}

