using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using AutoMapper;
using core.Entities.Oders;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using API.ApiExtensions;
using API.DTOs;
using core.Entities.Oders;
using API.ErrorsHandlers;

namespace API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        private readonly IOrders _iOrders;
        private readonly IMapper _mapper;
        public OrderController(IOrders iOrders, IMapper mapper)
        {
            _mapper = mapper;
            _iOrders = iOrders;
        }

[HttpPost]
         public async Task<ActionResult<OrderDTOFinal>> GetCreateOrder(OrderDTO orderDTO){

            var email = HttpContext.User.getEmailfromPrincipleClaims();
           Console.WriteLine(email);
           Console.WriteLine(55);
            var address = _mapper.Map<AddressDTO, OrderAddress>(orderDTO.AddressDTO);
            var order = await _iOrders.CreateOrdersAsync(
                email, orderDTO.DeliveryId, orderDTO.BasketID,address);
               

            if(order==null) return BadRequest(new Responses(400,"Orders not loaded"));

            return Ok(_mapper.Map<IReadOnlyList<OrderDTOFinal>>(order));
         }

    [HttpGet]
         public async Task<ActionResult<IReadOnlyList<OrderDTOFinal>>> GetOrderForUser(){

            var email = HttpContext.User.getEmailfromPrincipleClaims();

            var orders = await  _iOrders.GetOrdersAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<OrderDTOFinal>>(orders));

    }

    [HttpGet("{id}")]
         public async Task<ActionResult<OrderDTOFinal>> GetOrderForUser(int id){

            var email = HttpContext.User.getEmailfromPrincipleClaims();

            var order = await  _iOrders.GetOrdersByIdAsync(id,email);

            if(order==null) return NotFound(new Responses(400));

            return _mapper.Map<OrderDTOFinal>(order);

    }

    [HttpGet("delivery")]
         public async Task<ActionResult<IReadOnlyList<Delivery>>> GetDelivery(){

            return Ok(await _iOrders.GetDeliverysAsync());
         }

}
}