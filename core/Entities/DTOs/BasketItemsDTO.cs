using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class BasketItemsDTO
    {
        [Required]
        public int id {get; set;}
        [Required]
        public string prodName {get; set;}
        [Required]      
        public string prodPicture {get; set;}
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage = "Price  cannot be 0")]
        public decimal prodPrice {get; set;}
        [Required]
        [Range(1,double.MaxValue,ErrorMessage = "Quantity cannot be 0")]
        public int quantity {get; set;}
        [Required]
        public string productBrand {get; set;}
        [Required]
        public string productType {get; set;}

        
    }
}