using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using core.Entities;
using infrastructure.data;

namespace core.Specifications
{
    public class GetProductsWithBrandAndType : ProductSpecification<Products>
    {
        public GetProductsWithBrandAndType(string sort)
        {
            AddProdInclude(x=>x.productBrand);
            AddProdInclude(x=>x.productType);
            AddOrderBy(x=>x.prodName);  

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {

                    case "priceIncrease":
                    AddOrderBy(x=>x.prodPrice);  
                    break;

                    case "priceDecrease":
                    AddOrderByDescending(x=>x.prodPrice);  
                    break;

                    default:
                    AddOrderBy(x=>x.prodName);  
                    break;

                }

            } 
        
        }

        public GetProductsWithBrandAndType(int id) :
         base(x=>x.productId==id)
        {
            AddProdInclude(x=>x.productBrand);
            AddProdInclude(x=>x.productType);  
        }
    }
}