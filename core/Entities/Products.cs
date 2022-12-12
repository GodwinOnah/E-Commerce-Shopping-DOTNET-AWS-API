using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace core.Controllers
{
    public class Products : ProductEntities
    {
        public String prodName { get; set; }

        public String prodPicture { get; set; }

        public String prodDescription { get; set; }

        public int prodPrice { get; set; }

        public ProductBrand productBrand  { get; set; }

        public int productBrandId  { get; set; }

        public ProductType productType { get; set; }

        public int productTypeId { get; set; }

        
    }
}