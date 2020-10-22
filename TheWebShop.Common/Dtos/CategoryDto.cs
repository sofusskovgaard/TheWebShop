using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryDto ParentCategory { get; set; }

        public List<CategoryDto> ChildCategories { get; set; }
    }

    public class CategoryDetailedDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
