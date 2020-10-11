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
        Task<T> Get<T>(string bucket, string key) where T : BaseEntity;

        Task<T> Set<T>(T entity, string bucket, string key) where T : BaseEntity;

        Task<T> Set<T>(T entity, string bucket, string key, TimeSpan lifeSpan) where T : BaseEntity;
    }
}
