using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Dtos
{
    public class ProductPictureDto : BaseDto
    {
        public string Caption { get; set; }

        public byte[] Picture { get; set; }
        
        public string ContentType { get; set; }
    }

    public class ProductPictureDetailedDto : ProductPictureDto
    {

    }
}
