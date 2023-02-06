using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using core;

namespace API.DTOs
{
    public class BasketDTO
    {
        [Required]
     public string Id {get; set;}
    public List<BasketItems> Items {get; set;}
        
    }
}