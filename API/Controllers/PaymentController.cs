using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ErrorsHandlers;
using core;
using core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace API.Controllers
{
    public class PaymentController : ApiControllerBase
    {
        private readonly IPaymentService _payment;
        public PaymentController(IPaymentService payment)
        {
            _payment = payment;
        }

        [HttpPost("{basketId}")]
         public async Task<ActionResult<Basket>> CreateOrUpdatePaymentIntent(string basketId){
            var basket = await   _payment.CreateOrUpdateIntent(basketId);
            if(basket==null)
            return BadRequest(new Responses(400,"Problem with your basket"));
            return basket;
         }
    }

    //  [HttpPost]
    //      public async Task<ActionResult> stripeWebHook(){
    //              var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    //          Console.WriteLine("\n\n\n\n"+token+55+"\n\n\n\n");
    //     var tokenClaims = new JwtSecurityToken(token.Replace("Bear

    //        ;

    //         var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
    //      }
}