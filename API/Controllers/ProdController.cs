using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdController: ControllerBase
    {
        public storeProducts Products { get; }
        public ProdController(storeProducts products)
        {
            this.Products = products;
        }

        [HttpGet]

        public async Task<ActionResult<List<Products>>> GetProducts()
        {

            var productsList=await Products.Products.ToListAsync();

            return Ok(productsList);

        }

         [HttpGet("{id}")]

        public async Task<ActionResult<Products>> GetProducts(int id)
        {

            var product=await Products.Products.FindAsync(id);


            return product;

        }
        
    }
}