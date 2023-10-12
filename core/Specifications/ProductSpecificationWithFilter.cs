using core.Controllers;
using infrastructure.data;

namespace core.Specifications
{
    public class ProductSpecificationWithFilter : Specification<Products>
    {
        public ProductSpecificationWithFilter(ProductParameters parameters) : 
                base(x=>
                (string.IsNullOrEmpty(parameters.Search)||x.prodName.ToLower().Contains(parameters.Search))&&
                (!parameters.brandId.HasValue||x.productBrandId==parameters.brandId)&&
                (!parameters.typeId.HasValue||x.productTypeId==parameters.typeId))
        {


        }
    }
}