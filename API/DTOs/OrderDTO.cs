using API.DTOs;

namespace API.Controllers
{
    public class OrderDTO
    {

        public string basketID {get; set;}
         public int deliveryId {get; set;}

          public AddressDTO addressDTO {get; set;}
    }
}