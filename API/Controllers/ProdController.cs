
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdController: ControllerBase
    {
       
    
private readonly IgenericProductInterface<Products> _products;
        private readonly IgenericProductInterface<ProductBrand> _productBrands;

         private readonly IgenericProductInterface<ProductType> _productTypes;
        
        public ProdController(IgenericProductInterface<Products> products,
                                IgenericProductInterface<ProductBrand> productBrands,
                                IgenericProductInterface<ProductType> productTypes)
        {
            _productTypes = productTypes;
            _productBrands = productBrands;
            _products = products;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {

            var productsList=await _products.ListAllAsync();

            return Ok(productsList);

        }

         [HttpGet("{productId}")]
        public async Task<ActionResult<Products>> GetProducts(int productId)
        {

            var product=await _products.GetProductsByIdAdsync(productId);


            return product;

        }

        [HttpGet("{brands}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            var productBrandList=await _productBrands.ListAllAsync();

            return Ok(productBrandList);

        }

        [HttpGet("{types}")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {

            var productTypeList=await _productTypes.ListAllAsync();

             return Ok(productTypeList);

        }
        
    
}

}