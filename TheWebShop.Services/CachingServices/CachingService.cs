using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using StackExchange.Redis;

using TheWebShop.Data.Entities;

namespace TheWebShop.Services.CachingServices
{
    public class CachingService : ICachingService
    {
        private IConnectionMultiplexer _connection;

        public CachingService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connection = connectionMultiplexer;
        }

        public async Task<string> Get(string bucket, string key)
        {
            try
            {
                var db = _connection.GetDatabase();
                var result = await db.StringGetAsync($"{bucket}:{key}");

                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<T> Get<T>(string bucket, string key) where T : BaseEntity
        {
            try
            {
                var db = _connection.GetDatabase();
                var result = await db.StringGetAsync($"{bucket}:{key}");

                return JsonConvert.DeserializeObject<T>(result);
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> Set(string value, string bucket, string key)
        {
            try
            {
                var db = _connection.GetDatabase();

                await db.StringSetAsync($"{bucket}:{key}", value, new TimeSpan(7, 0, 0, 0));

                return value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> Set<T>(T value, string bucket, string key) where T : BaseEntity
        {
            try
            {
                var db = _connection.GetDatabase();
                var json = JsonConvert.SerializeObject(value);

                await db.StringSetAsync($"{bucket}:{key}", json, new TimeSpan(7, 0, 0, 0));

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> Set(string value, string bucket, string key, TimeSpan lifeSpan)
        {
            try
            {
                var db = _connection.GetDatabase();

                await db.StringSetAsync($"{bucket}:{key}", value, new TimeSpan(7, 0, 0, 0));

                return value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> Set<T>(T value, string bucket, string key, TimeSpan lifeSpan) where T : BaseEntity
        {
            try
            {
                var db = _connection.GetDatabase();
                var json = JsonConvert.SerializeObject(value);

                await db.StringSetAsync($"{bucket}:{key}", json, lifeSpan);

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
