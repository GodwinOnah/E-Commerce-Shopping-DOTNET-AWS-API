using API.DTOs;
using AutoMapper;
using core;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

   
    public class BasketController :ApiControllerBase
    { 
        private readonly IBasket _basket;
        private readonly IMapper _mapper;
        public BasketController(IBasket basket, IMapper mapper){
            _mapper = mapper;
            _basket = basket;
        }
        
        // [Cashing(600)]
        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasketById(string id){

            var basket= await _basket.GetBasketAsync(id);           
            return Ok(basket ?? new Basket(id));

        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(BasketDTO basketDTO)
        { 
    
            var basket =  _mapper.Map<BasketDTO,Basket>(basketDTO);
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