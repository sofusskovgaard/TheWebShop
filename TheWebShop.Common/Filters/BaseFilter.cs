using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Filters
{
    public abstract class BaseFilter<TOrderBy> : IBaseFilter<TOrderBy> where TOrderBy : Enum
    {
        protected BaseFilter()
        {
            Page = 1;

            PageSize = 12;
        }

        public string Query { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public abstract TOrderBy OrderBy { get; set; }
    }
}
