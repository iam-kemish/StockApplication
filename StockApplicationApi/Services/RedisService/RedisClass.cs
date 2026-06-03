using StackExchange.Redis;
using System.Text.Json;

namespace StockApplicationApi.Services.RedisService
{
    public class RedisClass: IRedisService
    {
        private readonly IDatabase _Db;
        
        private readonly IConnectionMultiplexer _redis;
        public RedisClass( IConnectionMultiplexer connection)
        {

            _redis = connection;
            _Db = _redis.GetDatabase(); 
        }
    
        public async Task<T> GetDatasAsync<T>(string key)
        {
            try
            {
                var value = await _Db.StringGetAsync(key);
                if (value.IsNullOrEmpty)
                {
                    return default!;
                }
                return JsonSerializer.Deserialize<T>(value!)!;
            }catch (RedisCommandException )
            {
              
                return default!;
            }
        }
        public async Task RemoveByPrefixAsync(string prefix)
        {
            try
            {
                var allKeys = new HashSet<RedisKey>();

                foreach (var endpoint in _redis.GetEndPoints())
                {
                    var server = _redis.GetServer(endpoint);
                    var PrefixSet = server.KeysAsync(pattern: $"{prefix}*");
                    await foreach (var key in PrefixSet)
                        allKeys.Add(key);
                }

                if (allKeys.Count > 0)
                    await _Db.KeyDeleteAsync(allKeys.ToArray());
            }
            catch (RedisException)
            {
              
            }
        }
        public async Task<bool> RemoveDataAsync(string key)
        {

            try
            {
                return await _Db.KeyDeleteAsync(key);
            } catch (RedisConnectionException)
            {
                return default!;
            }

        }
        
        public async Task<bool> SetDataAsync<T>(string key, T data, TimeSpan expiration )
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(data);
                return await _Db.StringSetAsync(key, jsonData, expiration);
            }
            catch (RedisCommandException)
            {
                return default!;
            }
        } 
    }
}
