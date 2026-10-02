using System.Text.Json;
using StackExchange.Redis;

namespace StockApplicationApi.Services.RedisService
{
    public class RedisClass : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        private readonly ILogger<RedisClass> _logger;

        public RedisClass(IConnectionMultiplexer redis, ILogger<RedisClass> logger)
        {
            _redis = redis;
            _db = redis.GetDatabase();
            _logger = logger;
        }

        // RedisTimeoutException is NOT a RedisException, so check both
        private static bool IsRedisFailure(Exception ex) =>
            ex is RedisException or RedisTimeoutException;

        public async Task<T?> GetDatasAsync<T>(string key)
        {
            try
            {
                var value = await _db.StringGetAsync(key);
                if (value.IsNullOrEmpty) return default;
                return JsonSerializer.Deserialize<T>(value.ToString());
            }
            catch (JsonException ex)
            {
                _logger.LogWarning(ex, "Bad cached JSON for {Key}, removing it", key);
                await RemoveDataAsync(key);
                return default; 
            }
            catch (Exception ex) when (IsRedisFailure(ex))
            {
                _logger.LogWarning(ex, "Redis read failed for {Key}, falling back to DB", key);
                return default;
            }
        }

        public async Task<bool> SetDataAsync<T>(string key, T data, TimeSpan expiration)
        {
            try
            {
                var json = JsonSerializer.Serialize(data);
                return await _db.StringSetAsync(key, json, expiration);
            }
            catch (Exception ex) when (IsRedisFailure(ex))
            {
                _logger.LogWarning(ex, "Redis write failed for {Key}", key);
                return false;
            }
        }

        public async Task<bool> RemoveDataAsync(string key)
        {
            try
            {
                return await _db.KeyDeleteAsync(key);
            }
            catch (Exception ex) when (IsRedisFailure(ex))
            {
                _logger.LogError(ex, "Cache invalidation failed for {Key}; stale until TTL", key);
                return false;
            }
        }

        public async Task RemoveByPrefixAsync(string prefix)
        {
            try
            {
                var keys = new HashSet<RedisKey>();
                foreach (var endpoint in _redis.GetEndPoints())
                {
                    var server = _redis.GetServer(endpoint);
                    if (server.IsReplica || !server.IsConnected) continue;

                    await foreach (var key in server.KeysAsync(pattern: $"{prefix}*"))
                        keys.Add(key);
                }

                if (keys.Count > 0)
                    await _db.KeyDeleteAsync(keys.ToArray());
            }
            catch (Exception ex) when (IsRedisFailure(ex))
            {
                _logger.LogError(ex, "Cache invalidation failed for prefix {Prefix}; stale until TTL", prefix);
            }
        }
    }
}