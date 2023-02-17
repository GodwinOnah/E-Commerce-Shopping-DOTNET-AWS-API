using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities.Oders;

namespace API.DTOs
{
    public class OrderDTOFinal
    {
         public int  Id {get; set;}
         public string  Email {get; set;}
        public string  Delivery {get; set;}
        public decimal OrderPrice {get; set;}
        public OrderAddress Address {get; set;}
        public IReadOnlyList<ItemOrderedDTO > ItemOrdered {get; set;}
        public string  OrderStatus {get; set;}
        public DateTime  OderDate {get; set;}
        public decimal  SubTotal {get; set;}
         public decimal  Total {get; set;}
        public string  PaymentIntentId {get; set;}
        
    }
}