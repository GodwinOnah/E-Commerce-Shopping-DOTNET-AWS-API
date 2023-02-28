using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core;
using core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return await   _payment.CreateOrUpdateIntent(basketId);
         }
    }
}