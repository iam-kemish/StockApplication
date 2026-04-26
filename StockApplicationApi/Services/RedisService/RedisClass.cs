using StackExchange.Redis;
using System.Text.Json;

namespace StockApplicationApi.Services.RedisService
{
    public class RedisClass: IRedisService
    {
        private readonly IDatabase _Db;
        private readonly IConfiguration configuration;
        private readonly IConnectionMultiplexer _redis;
        public RedisClass(IConfiguration configuration)
        {
            this.configuration = configuration;
            _redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")!);
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

        public async Task<bool> SetDataAsync<T>(string key, T data, DateTime expiration )
        {
            var expiryTimeSpan = expiration - DateTime.UtcNow;
     
            if (expiryTimeSpan.TotalSeconds <= 0)
            {
                return false;
            }

            var jsonData = JsonSerializer.Serialize(data);
            return await _Db.StringSetAsync(key, jsonData, expiryTimeSpan);
        } 
    }
}
