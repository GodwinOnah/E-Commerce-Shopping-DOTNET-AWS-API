using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{

   
    public class ProductEntities
    {

         [Key]
        public int productId { get; set; }
    }
}