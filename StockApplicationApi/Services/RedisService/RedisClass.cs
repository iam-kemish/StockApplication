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
           var value =await _Db.StringGetAsync(key);
            if (value.IsNullOrEmpty)
            {
                return default!;
            }
            return JsonSerializer.Deserialize<T>(value!)!;
        }
        public async Task RemoveByPrefixAsync(string prefix)
        {
          
            var endpoints = _redis.GetEndPoints();
            var server = _redis.GetServer(endpoints[0]);

            var keys = server.Keys(pattern: $"{prefix}*").ToArray();
            if (keys.Any())
                await _Db.KeyDeleteAsync(keys);

        }

        public async Task<bool> RemoveDataAsync(string key)
        {
           
         return await _Db.KeyDeleteAsync(key);
            
        }

        public async Task<bool> SetDataAsync<T>(string key, T data, TimeSpan expiration )
        {
           
            var jsonData = JsonSerializer.Serialize(data);
            return await _Db.StringSetAsync(key, jsonData, expiration);
        } 
    }
}
