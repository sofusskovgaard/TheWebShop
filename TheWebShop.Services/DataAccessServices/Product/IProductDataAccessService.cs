using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheWebShop.Common.Filters.Product;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.ProductPicture;

namespace TheWebShop.Services.DataAccessServices.Product
{
    public interface IProductDataAccessService : IBaseDataAccessService<ProductEntity, ProductFilter, ProductOrderBy>
    {
        Task<IEnumerable<ProductPictureEntity>> GetPicturesForProduct(int entityId);

        Task<bool> UploadPictures(int entityId, IEnumerable<ProductPictureEntity> productPictures);

        Task<bool> DeletePictureById(int entityId);
    }
}
