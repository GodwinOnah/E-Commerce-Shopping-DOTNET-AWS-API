using System;
using System.Collections.Generic;
using System.Linq;
using infrastructure.data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Entities;
using infrastructure.data.ProductsData;
using core.Interfaces;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdController: ControllerBase
    {
        private readonly IgenericProductInterface<Products> _products;

        private readonly IgenericProductInterface<ProductBrand> _productBrands;
        private readonly IgenericProductInterface<ProductType> _productTypes;
        public ProdController(IgenericProductInterface<Products> products,IgenericProductInterface<ProductBrand> productBrands,IgenericProductInterface<ProductType> productTypes)
        
        {
            _products = products;
             _productBrands = productBrands;
            _productTypes = productTypes;
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
        
    
}}