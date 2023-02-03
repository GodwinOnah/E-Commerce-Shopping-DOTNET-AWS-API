using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Specifications
{
    public class ProductsPagination<T> where T : class
    {
        public ProductsPagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            this.pageSize = pageSize;
            this.count = count;
            this.data = data;
        }

        public int PageIndex {get; set;}

        public int pageSize {get; set;}

        public int count {get; set;}

        public IReadOnlyList<T> data {get; set;}
    }
}