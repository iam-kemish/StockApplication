namespace StockApplicationApi.Services.RedisService
{
    public interface IRedisService
    {
        Task<T> GetDatasAsync<T>(string key);
        Task<bool> SetDataAsync<T>(string key, T data, TimeSpan expiration );
        Task<bool> RemoveDataAsync(string key);
    }
}

