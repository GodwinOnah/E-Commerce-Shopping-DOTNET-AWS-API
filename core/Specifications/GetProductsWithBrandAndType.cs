using core.Controllers;
using infrastructure.data;

namespace core.Specifications
{
    public class GetProductsWithBrandAndType : Specification<Products>
    {
        public GetProductsWithBrandAndType(ProductParameters parameters):
        base(x=>
                (string.IsNullOrEmpty(parameters.Search)||x.prodName.ToLower().Contains(parameters.Search))&&
                (!parameters.brandId.HasValue||x.productBrandId==parameters.brandId)&&
                (!parameters.typeId.HasValue||x.productTypeId==parameters.typeId)/*Filtering into a list by brand or type id*/)
        {
            AddProdInclude(x=>x.productBrand);
            AddProdInclude(x=>x.productType);
            AddOrderBy(x=>x.prodName);  //default order by product name
            ApplyPagging(parameters.PageSize*(parameters.pageIndex-1),parameters.PageSize);
            

            if(!string.IsNullOrEmpty(parameters.sort))
            {
                switch(parameters.sort)//this code sorts the price in a particular order
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
         base(x=>x.id==id/*Filtering into a single product*/)
        {
            AddProdInclude(x=>x.productBrand);
            AddProdInclude(x=>x.productType);  
        }
    }
}