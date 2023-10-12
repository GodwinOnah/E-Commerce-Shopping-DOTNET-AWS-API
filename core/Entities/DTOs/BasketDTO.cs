using System.ComponentModel.DataAnnotations;
using core;

namespace API.DTOs
{
    public class BasketDTO
    {
        [Required]
    public string id {get; set;}
    public List<BasketItems> items {get; set;}
    public string clientSecret {get; set;}
    public string paymentIntentId {get; set;}
    public int? deliveryId {get; set;}
    public decimal? deliveryPrice {get; set;}
     public string? deliveryName {get; set;}
     public string? deliveryTime {get; set;}
     public string? deliveryDescription {get; set;}


        
    }
}