using core.Entities.Oders;

namespace API.DTOs
{
    public class OrderDTOFinal
    {
        public int  id {get; set;}
         public string  Email {get; set;}
        public string  delivery {get; set;}
        public decimal orderPrice {get; set;}
        public ShippingAddress shippingAddress {get; set;}
        public IReadOnlyList<ItemOrderedDTO > itemOrdered {get; set;}
        public string  orderStatus {get; set;}
        public DateTime  orderDate {get; set;}
        public decimal  subTotal {get; set;}
         public decimal  total {get; set;}
        public string  paymentIntentId {get; set;}
        public string confirmation {get; set;}
        
    }
}