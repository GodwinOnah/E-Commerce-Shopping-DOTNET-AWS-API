using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProdController: ControllerBase
    {

        [HttpGet]

        public string GetProducts()
        {

   return "I am fine with this networking for u";

        }

         [HttpGet("{id}")]

        public string GetProduct(int id)
        {

   return "this is a product with id: "+id;

        }
        
    }
}