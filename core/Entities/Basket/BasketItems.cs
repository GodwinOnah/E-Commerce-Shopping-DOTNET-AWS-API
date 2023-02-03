using Newtonsoft.Json;

namespace core
{ 
   
    public class BasketItems
    {
        public int productId {get; set;}
        public string prodName {get; set;}
        
        public string prodPicture {get; set;}

        public decimal prodPrice {get; set;}

        public int quantity {get; set;}

        public string productBrand {get; set;}

        public string productType {get; set;}

             
    }
}