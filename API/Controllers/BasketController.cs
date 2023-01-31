using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

   
    public class BasketController :ApiControllerBase
    { 
        private readonly IBasket _basket;
        public BasketController(IBasket basket){
            _basket = basket;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasketById(string id){

            var basket= await _basket.GetBasketAsync(id);
            
            return Ok(basket ?? new Basket(id));

        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket)
        { 

            Console.WriteLine(basket.Items);
            var update = await  _basket.UpdateBasketAsync(basket);
            return Ok(update);

        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
          await  _basket.DeleteBasketAsync(id);
            
        }
    }
    }