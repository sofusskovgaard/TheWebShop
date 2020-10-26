using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheWebShop.WebApp.Api
{
    public abstract class BaseApiController<TFilter> : ControllerBase
    {
        public abstract Task<IActionResult> GetByFilter(TFilter filter);
        
        public abstract Task<IActionResult> GetById(int entityId);

//        public abstract Task<IActionResult> UpdateById(int entityId, object data);
//
//        public abstract Task<IActionResult> Create(object data);
        
        public abstract Task<IActionResult> DeleteById(int entityId);
        
        protected async Task<T> TryAsync<T>(Func<T> stuffToTry)
        {
            try
            {
                return await Task.Run(stuffToTry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<T> TryAsync<T>(Func<Task<T>> stuffToTry)
        {
            try
            {
                return await stuffToTry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}