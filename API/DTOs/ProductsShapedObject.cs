using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ProductsShapedObject
    {
        public int prodId { get; set; }
        public String prodName { get; set; }

        public String prodDescription { get; set; }

        public decimal prodPrice { get; set; }

        public String prodPicture { get; set; }

        public String productBrand  { get; set; }
        public String productType { get; set; }
        
        
    }
}