using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Distributed;

using TheWebShop.Data.Entities;

namespace TheWebShop.Services.CachingServices
{
    public interface ICachingService
    {
        Task<string> Get(string bucket, string key);

        Task<T> Get<T>(string bucket, string key) where T : BaseEntity;


        Task<string> Set(string value, string bucket, string key);

        Task<T> Set<T>(T value, string bucket, string key) where T : BaseEntity;


        Task<string> Set(string value, string bucket, string key, TimeSpan lifeSpan);

        Task<T> Set<T>(T value, string bucket, string key, TimeSpan lifeSpan) where T : BaseEntity;
    }
}
