namespace core
{
    public class Basket
    {
        public Basket()
        {

       }
        public Basket(string id)
        {
            Id = id;
        }

         public string Id {get; set;}
        public List<BasketItems> Items {get; set;}
                      = new List<BasketItems>();
        public string clientSecret {get; set;}
        public string paymentIntentId {get; set;}
        public int? deliveryId {get; set;}  
         public decimal? deliveryPrice {get; set;}
         public string? deliveryName {get; set;}
         public string? deliveryTime {get; set;}
         public string? deliveryDescription {get; set;}
 
          }

   
}