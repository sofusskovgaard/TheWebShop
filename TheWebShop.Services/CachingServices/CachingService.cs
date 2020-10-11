using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using TheWebShop.Data.Entities;

namespace TheWebShop.Services.CachingServices
{
    public class CachingService : ICachingService
    {
        private IDistributedCache _cache;

        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> Get<T>(string bucket, string key) where T : BaseEntity
        {
            try
            {
                var json = await _cache.GetStringAsync($"{bucket}:{key}");
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return null;
            }
        }

        public async Task<T> Set<T>(T entity, string bucket, string key) where T : BaseEntity
        {
            try
            {
                var json = JsonConvert.SerializeObject(entity);

                var options = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = new TimeSpan(7, 0, 0, 0)
                };

                await _cache.SetStringAsync($"{bucket}:{key}", json, options);

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> Set<T>(T entity, string bucket, string key, TimeSpan lifeSpan) where T : BaseEntity
        {
            try
            {
                var json = JsonConvert.SerializeObject(entity);

                var options = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = lifeSpan
                };

                await _cache.SetStringAsync($"{bucket}:{key}", json, options);

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
