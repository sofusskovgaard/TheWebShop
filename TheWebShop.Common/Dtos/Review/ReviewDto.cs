using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos.Product;

namespace TheWebShop.Common.Dtos.Review
{
    public class ReviewDto : BaseDto
    {
        public int Rating { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }
    }

    public class ReviewDetailedDto : ReviewDto
    {

    }
}
