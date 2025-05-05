using StackExchange.Redis;
using System.Text.Json;

public class RedisCacheHelper
{
    private readonly IDatabase _db;
    public RedisCacheHelper(string connectionString)
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _db = redis.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, json, expiry);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var json = await _db.StringGetAsync(key);
        if (json.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(json);
    }
}
