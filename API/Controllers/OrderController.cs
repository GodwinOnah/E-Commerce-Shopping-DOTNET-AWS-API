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
using API.Helper;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using core.Entities.Identity;

namespace API.Controllers
{
    public class OrderController : ApiControllerBase
    {
        private readonly IOrders _iOrders;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrders iOrders, IMapper mapper,UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _iOrders = iOrders;
        }

[HttpPost]
         public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO){
        //      var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //      Console.WriteLine("\n\n\n\n"+token+55+"\n\n\n\n");
        // var tokenClaims = new JwtSecurityToken(token.Replace("Bearer ", string.Empty));
        //  var email = tokenClaims.Payload["email"].ToString();

        //  var emaili = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        //     var user = await _userManager.FindByEmailAsync(emaili);
        // //      Console.WriteLine("\n\n\n"+user+"\n\n\n");

        //  var user = await _userManager.FindByEmailAsync(emaili);

            var email = HttpContext.User.getEmailfromPrincipleClaims();
            //  Console.WriteLine("\n\n\norder11"+email+"\n\n\n");
           
            // var email ="dan@gmail.com";
            var address = _mapper.Map<AddressDTO, ShippingAddress>(orderDTO.shippingAddress);
            var order = await _iOrders.CreateOrdersAsync(email, orderDTO.basketId,
            orderDTO.deliveryId,address); 
            // Console.WriteLine("\n\n\n\n\n"+order.delivery.delName+"\n\n\n\n\n"); 
            if(order==null) return BadRequest(new Responses(400,"Orders not loaded"));
            var xorder = order;
            // Console.WriteLine("\n\n\n\n\n"+xorder+"\n\n\n\n\n"); 

            return Ok(xorder);
         }

    // [Cashing(600)]
    [HttpGet]
         public async Task<ActionResult<IReadOnlyList<OrderDTOFinal>>> GetOrderForUser(){
        //      var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        //      Console.WriteLine("\n\n\n\n"+token+55+"\n\n\n\n");
        // var tokenClaims = new JwtSecurityToken(token.Replace("Bearer ", string.Empty));
        //  var email = tokenClaims.Payload["email"].ToString();
        
            var email = HttpContext.User.getEmailfromPrincipleClaims();
            // var email ="dan@gmail.com";
            //  Console.WriteLine("\n\n\n\n\n"+2222+"\n\n\n\n\n");
            var orders = await  _iOrders.GetOrdersAsync(email);
            
            return Ok(_mapper.Map<IReadOnlyList<OrderDTOFinal>>(orders));
    }

    // [Cashing(600)]
    [HttpGet("{id}")]
         public async Task<ActionResult<OrderDTOFinal>> GetOrderForUser(int id){
            var email = HttpContext.User.getEmailfromPrincipleClaims();
            //  var email ="dan@gmail.com";
            var order = await  _iOrders.GetOrdersByIdAsync(id,email);
            if( order == null ) return NotFound(new Responses(400));
            return _mapper.Map<OrderDTOFinal>(order);
    }

    // [Cashing(600)]
    [HttpGet("delivery")]
         public async Task<ActionResult<IReadOnlyList<Delivery>>> GetDelivery(){
            var delivery = await _iOrders.GetDeliverysAsync();
            return Ok(delivery);
         }
}
}