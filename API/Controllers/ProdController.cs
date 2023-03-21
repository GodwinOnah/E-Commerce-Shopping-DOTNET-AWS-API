
using API.DTOs;
using API.ErrorsHandlers;
using API.Helper;
using AutoMapper;
using core.Controllers;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

   
    public class ProductsController: ApiControllerBase
    {
        private readonly IgenericInterfaceRepository<Products> _products;
        private readonly IgenericInterfaceRepository<ProductBrand> _productBrands;

         private readonly IgenericInterfaceRepository<ProductType> _productTypes;

         private readonly IMapper _imapper;
        
        public ProductsController(IgenericInterfaceRepository<Products> products,
                                IgenericInterfaceRepository<ProductBrand> productBrands,
                                IgenericInterfaceRepository<ProductType> productTypes,
                                IMapper imapper)
                            {
                                _productTypes = productTypes;
                                _productBrands = productBrands;
                                _products = products;
                            _imapper = imapper;
                            }
        // [Cashing(600)]
        [HttpGet]
        public async Task<ActionResult<ProductsPagination<ProductsShapedObject>>> GetProducts(
            [FromQuery]ProductParameters parameters)//The [FromQuery] help the controller trace the parameter from the object passed
        {
             var countPageSpecification = new ProductSpecificationWithFilter(parameters);
             var totalProducts = await _products.CountPage(countPageSpecification);
             var specification = new GetProductsWithBrandAndType(parameters);
             var productsList = await _products.ListAllAsync(specification);
             var data= _imapper.Map<IReadOnlyList<Products>,
                             IReadOnlyList<ProductsShapedObject>>(productsList);
             return Ok(new ProductsPagination<ProductsShapedObject>
                (parameters.pageIndex,parameters.PageSize,totalProducts,data));
        }

        // [Cashing(600)]
        [HttpGet("{productId}")]// Notice the curly braces
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsShapedObject>> GetProducts(int productId)
        {
            var specification = new GetProductsWithBrandAndType(productId);
            var product = await _products.GetProductsWithSpecification(specification);
            if(product==null) return NotFound(new Responses(400));
            return _imapper.Map<Products,ProductsShapedObject>(product);
        }

        // [Cashing(600)]
        [HttpGet("brands")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            var productBrandList=await _productBrands.ListAllAsync();          
            return Ok(productBrandList);
        }

        // [Cashing(600)]
        [HttpGet("types")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            var productTypeList = await _productTypes.ListAllAsync();
             return Ok(productTypeList);
        }   
}
}