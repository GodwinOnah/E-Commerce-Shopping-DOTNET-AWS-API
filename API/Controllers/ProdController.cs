
using API.DTOs;
using AutoMapper;
using core.Controllers;
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

         private readonly IMapper _imapper;
        
        public ProductsController(IgenericProductInterface<Products> products,
                                IgenericProductInterface<ProductBrand> productBrands,
                                IgenericProductInterface<ProductType> productTypes,
                                IMapper imapper)
        {
            _productTypes = productTypes;
            _productBrands = productBrands;
            _products = products;
           _imapper = imapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductsPagination<ProductsShapedObject>>> GetProducts(
            [FromQuery]ProductParameters parameters)//The [FromQuery] help the controller trace the parameter from the object passed

        {
             var countPageSpecification= new ProductSpecificationWithFilter(parameters);

             var totalProducts= await _products.CountPage(countPageSpecification);

             var specification= new GetProductsWithBrandAndType(parameters);

             var productsList= await _products.ListAllAsync(specification);

             var data= _imapper.Map<IReadOnlyList<Products>,
             IReadOnlyList<ProductsShapedObject>>(productsList);

             return Ok(new ProductsPagination<ProductsShapedObject>
             (parameters.pageIndex,parameters.PageSize,totalProducts,data));

        }

        [HttpGet("{productId}")]// Notice the curly braces
        public async Task<ActionResult<ProductsShapedObject>> GetProducts(int productId)
        {
            var specification=new GetProductsWithBrandAndType(productId);
            var product=await _products.GetProductsWithSpecification(specification);
            return _imapper.Map<Products,ProductsShapedObject>(product);

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