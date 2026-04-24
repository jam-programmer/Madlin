namespace Application.Services.Cache;

public interface ICacheService
{
    Task<TModel> GetFromCacheAsync<TModel>(string cacheKey);
    Task SetToCacheAsync<TModel>(string cacheKey, TModel model,TimeSpan time);
    Task RemoveFromCacheAsync(string cacheKey);
}
