using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Dtos
{
    public class ReviewDto : BaseDto
    {
        public int Rating { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }
        
        public ProductDto Product { get; set; }
    }

    public class ReviewDetailedDto : ReviewDto
    {

    }
}
