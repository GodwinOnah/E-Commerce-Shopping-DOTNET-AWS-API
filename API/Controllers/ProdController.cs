
using API.DTOs;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IgenericProductInterface<Products> _products;
        private readonly IgenericProductInterface<ProductBrand> _productBrands;

         private readonly IgenericProductInterface<ProductType> _productTypes;
        
        public ProductsController(IgenericProductInterface<Products> products,
                                IgenericProductInterface<ProductBrand> productBrands,
                                IgenericProductInterface<ProductType> productTypes)
        {
            _productTypes = productTypes;
            _productBrands = productBrands;
            _products = products;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsShapedObject>>> GetProducts()
        {
            var specification=new GetProductsWithBrandAndType();
            var productsList=await _products.ListAllAsync(specification);

            return productsList.Select(product=>new ProductsShapedObject
            {
                prodId=product.productId,
                prodName=product.prodName,
                prodDescription=product.prodDescription,
                prodPrice=product.prodPrice,
                prodPicture=product.prodPicture,
                productBrand=product.productBrand.Name,
                productType=product.productType.Name

            }).ToList();
        
            

        }

        [HttpGet("{productId}")]// Notice the curly braces
        public async Task<ActionResult<ProductsShapedObject>> GetProducts(int productId)
        {
            var specification=new GetProductsWithBrandAndType(productId);
            var product=await _products.GetProductsWithSpecification(specification);
            return new ProductsShapedObject
            {
                prodId=product.productId,
                prodName=product.prodName,
                prodDescription=product.prodDescription,
                prodPrice=product.prodPrice,
                prodPicture=product.prodPicture,
                productBrand=product.productBrand.Name,
                productType=product.productType.Name

            };

        }

        [HttpGet("brands")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            var productBrandList=await _productBrands.ListAllAsync();

            return Ok(productBrandList);

        }

        [HttpGet("types")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {

            var productTypeList=await _productTypes.ListAllAsync();

             return Ok(productTypeList);

        }
        
    
}

}