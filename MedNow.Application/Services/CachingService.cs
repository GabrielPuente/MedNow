using MedNow.Application.Contracts.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MedNow.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;

        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, object value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), GetCacheOptions(1200, 3600));
        }

        private static DistributedCacheEntryOptions GetCacheOptions(int slidingExpirationSecs, int absoluteExpirationSecs)
        {
            var cacheOptions = new DistributedCacheEntryOptions();

            cacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(slidingExpirationSecs));
            cacheOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(absoluteExpirationSecs));

            return cacheOptions;
        }
    }
}
