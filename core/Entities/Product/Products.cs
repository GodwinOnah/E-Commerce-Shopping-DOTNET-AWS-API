using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace core.Controllers
{
    public class Products : ProductEntities
    {
        public string prodName { get; set; }

        public string prodPicture { get; set; }

        public string prodDescription { get; set; }

        public decimal prodPrice { get; set; }

        public ProductBrand productBrand  { get; set; }

        public int productBrandId  { get; set; }

        public ProductType productType { get; set; }

        public int productTypeId { get; set; }

        
    }
}