using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Filters
{
    public interface IBaseFilter<TOrderBy> where TOrderBy : Enum
    {
        string Query { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }

        TOrderBy OrderBy { get; set; }
    }
}
