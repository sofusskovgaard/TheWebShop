using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.ProductPicture;
using TheWebShop.Services.DataAccessServices.Product;

namespace TheWebShop.Services.EntityServices.ProductService
{
    public class ProductService : BaseEntityService<ProductEntity, ProductFilter, ProductOrderBy>, IProductService
    {
        private readonly IProductDataAccessService _productDataAccessService;

        private readonly IMapper _mapper;
        
        public ProductService(IProductDataAccessService productDataAccessService, IMapper mapper)
        {
            _productDataAccessService = productDataAccessService;

            _mapper = mapper;
        }
        
        public override async Task<T> GetById<T>(int entityId)
        {
            var entity = await _productDataAccessService.GetById(entityId);
            return _mapper.Map<T>(entity);
        }

        public override async Task<IEnumerable<T>> GetByFilter<T>(ProductFilter filter)
        {
            var entities = await _productDataAccessService.GetByFilter(filter);
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        public override async Task<T> UpdateById<T>(int entityId, object data)
        {
            var entity = await _productDataAccessService.UpdateById(entityId, data);
            return _mapper.Map<T>(entity);
        }

        public override async Task<T> Create<T>(ProductEntity entity)
        {
            var newEntity = await _productDataAccessService.Create(entity);
            return _mapper.Map<T>(newEntity);
        }

        public override async Task<bool> DeleteById(int entityId)
        {
            return await _productDataAccessService.DeleteById(entityId);
        }

        public override async Task<int> CountEntitiesByFilter(ProductFilter filter)
        {
            return await _productDataAccessService.CountEntitiesByFilter(filter);
        }

        public async Task<IEnumerable<ProductPictureDto>> GetPicturesForProduct(int entityId)
        {
            var pictures = await _productDataAccessService.GetPicturesForProduct(entityId);
            return _mapper.Map<IEnumerable<ProductPictureDto>>(pictures);
        }

        public async Task<bool> UploadPictures(int entityId, IEnumerable<ProductPictureDto> productPictures)
        {
            return await _productDataAccessService.UploadPictures(entityId, _mapper.Map<IEnumerable<ProductPictureEntity>>(productPictures));
        }

        public async Task<bool> DeletePictureById(int entityId)
        {
            return await _productDataAccessService.DeletePictureById(entityId);
        }
    }
}
