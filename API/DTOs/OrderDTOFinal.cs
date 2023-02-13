using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities.Oders;

namespace API.DTOs
{
    public class OrderDTOFinal
    {
         public int  id {get; set;}
         public string  email {get; set;}
        public string  delivery {get; set;}
        public decimal orderPrice {get; set;}
        public OrderAddress address {get; set;}
        public IReadOnlyList<ItemOrderedDTO > itemOrdered {get; set;}
        public string  orderStatus {get; set;}
        public DateTime  oderDate {get; set;}
        public decimal  subTotal {get; set;}
         public decimal  Total {get; set;}
        public string  paymentIntentId {get; set;}
        
    }
}