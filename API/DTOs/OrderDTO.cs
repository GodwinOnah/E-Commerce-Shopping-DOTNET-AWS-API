using API.DTOs;

namespace API.Controllers
{
    public class OrderDTO
    {

        public string BasketID {get; set;}
         public int DeliveryId {get; set;}

          public AddressDTO AddressDTO {get; set;}
    }
}