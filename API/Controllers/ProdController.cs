using System;
using System.Collections.Generic;
using System.Linq;
using infrastructure.data;
using System.Threading.Tasks;
using core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

         [HttpGet("{id}")]

        public async Task<ActionResult<Products>> GetProducts(int id)
        {

            var product=await _productsRep.GetProductsByIDAdsync(id);


            return product;

        }
        
    }
}