using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BasketController :ControllerBase
    { 
        private readonly IBasket _basket;
        public BasketController(IBasket basket){
            _basket = basket;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasketById(string Id){

            var basket= await _basket.GetBasketAsync(Id);
            return Ok(basket??new Basket(Id));

        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket)
        {
           var update= await  _basket.UpdateBasketAsync(basket);
            return Ok(update);

        }

          [HttpDelete]
        public async Task DeleteBasket(string id)
        {
          await  _basket.DeleteBasketAsync(id);
            
        }
    }
    }