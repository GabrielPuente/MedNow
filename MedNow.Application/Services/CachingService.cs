using MedNow.Application.Contracts.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace MedNow.Application.Services
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };
        }

        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key);
        }

        public async Task SetAsync(string key, object value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), _options);
        }
    }
}
