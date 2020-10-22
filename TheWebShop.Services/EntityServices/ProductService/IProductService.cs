using System.Collections.Generic;
using System.Threading.Tasks;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Services.EntityServices.ProductService
{
    public interface IProductService : IBaseEntityService<ProductEntity, ProductFilter, ProductOrderBy>
    {
        Task<IEnumerable<ProductPictureDto>> GetPicturesForProduct(int entityId);
        
        Task<bool> UploadPictures(int entityId, IEnumerable<ProductPictureDto> productPictures);

        Task<bool> DeletePictureById(int entityId);
    }
}