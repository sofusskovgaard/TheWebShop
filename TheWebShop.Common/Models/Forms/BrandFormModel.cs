using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Models.Product;

namespace TheWebShop.Common.Models.Forms
{
    public class BrandFormModel : BaseFormModel
    {
        public string Name { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
