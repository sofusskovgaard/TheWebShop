using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TheWebShop.Common.Filters.Order;
using TheWebShop.Data.Entities.Order;
using TheWebShop.Services.DataAccessServices.Order;

namespace TheWebShop.Services.EntityServices.OrderService
{
    public class OrderService : BaseEntityService<OrderEntity, OrderFilter, OrderOrderBy>
    {
        private readonly IOrderDataAccessService _orderDataAccessService;
        
        private readonly IMapper _mapper;
        
        public OrderService(IOrderDataAccessService orderDataAccessService, IMapper mapper)
        {
            _orderDataAccessService = orderDataAccessService;

            _mapper = mapper;
        }
        
        public override async Task<T> GetById<T>(int entityId)
        {
            var entity = await _orderDataAccessService.GetById(entityId);
            return _mapper.Map<T>(entity);
        }

        public override async Task<IEnumerable<T>> GetByFilter<T>(OrderFilter filter)
        {
            var entities = await _orderDataAccessService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public override async Task<T> UpdateById<T>(int entityId, object data)
        {
            var entity = await _orderDataAccessService.UpdateById(entityId, data);
            return _mapper.Map<T>(entity);
        }

        public override async Task<T> Create<T>(OrderEntity entity)
        {
            var newEntity = await _orderDataAccessService.Create(entity);
            return _mapper.Map<T>(newEntity);
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            return await _orderDataAccessService.DeleteById(entityId);
        }

        public override async Task<int> CountEntitiesByFilter(OrderFilter filter)
        {
            return await _orderDataAccessService.CountEntitiesByFilter(filter);
        }
    }
}