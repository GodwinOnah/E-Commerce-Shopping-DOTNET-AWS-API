using System;
using System.Collections.Generic;
using System.Linq;
using infrastructure.data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Entities;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdController: ControllerBase
    {
        private readonly ProductRepo _productsRep;
        public ProdController(ProductRepo productsRep)
        {
            _productsRep = productsRep;
        }

        [HttpGet]

        public async Task<ActionResult<List<Products>>> GetProducts()
        {

            var productsList=await _productsRep.GetProductsAdsync();

            return Ok(productsList);

        }

         [HttpGet("{productId}")]

        public async Task<ActionResult<Products>> GetProducts(int productId)
        {

            var product=await _productsRep.GetProductsByIDAdsync(productId);


            return product;

        }

        [HttpGet("{brands}")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            var productBrandList=await _productsRep.GetProductBrandAdsync();

            return Ok(productBrandList);

        }

        [HttpGet("{types}")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {

            var productTypeList=await _productsRep.GetProductTypeAdsync();

            


            return Ok(productTypeList);

        }
        
    
}}