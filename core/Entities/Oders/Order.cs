namespace core.Entities.Oders
{
    public class Order : ProductEntities
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<ItemOrdered> itemOrdered,
         string email, Delivery delivery, ShippingAddress address,
         string paymentIntentId, decimal subTotal)
        {
            this.Email = email;
            this.delivery = delivery;
            this.address = address;
            this.itemOrdered = itemOrdered;
            this.subTotal = subTotal;
            this.paymentIntentId = paymentIntentId;     
        }

        public string  Email {get; set;}
        public Delivery  delivery {get; set;}
        public ShippingAddress address {get; set;}
        public IReadOnlyList<ItemOrdered > itemOrdered {get; set;}
        public OrderStatus  orderStatus {get; set;} = OrderStatus.Pending;
        public DateTime  orderDate {get; set;} = DateTime.UtcNow;
        public decimal  subTotal {get; set;}
        public string  paymentIntentId {get; set;}
        public string confirmation {get; set;} = "Awaits confirmation";

        public decimal GetTotal(){
            return subTotal + delivery.delPrice;
        }
    }
}