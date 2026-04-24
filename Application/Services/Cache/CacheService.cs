using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Services.Cache;

public class CacheService : ICacheService
{
    readonly IDistributedCache _distributedCache;
    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<TModel?> GetFromCacheAsync<TModel>(string cacheKey)
    {
        string? jsonData = await _distributedCache.GetStringAsync(cacheKey);

        if (string.IsNullOrEmpty(jsonData))
        {
            return default(TModel);
        }

        var model = JsonConvert.DeserializeObject<TModel>(jsonData);
        return model;
    }

    public async Task SetToCacheAsync<TModel>(string cacheKey, TModel model, TimeSpan time)
    {
        string jsonData = JsonConvert.SerializeObject(model);
        await _distributedCache.SetStringAsync(cacheKey, jsonData, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = time
        });
    }

    public async Task RemoveFromCacheAsync(string cacheKey)
    {
        await _distributedCache.RemoveAsync(cacheKey);
    }
}
