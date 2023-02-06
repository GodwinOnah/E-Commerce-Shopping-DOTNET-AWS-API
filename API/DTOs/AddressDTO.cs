using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AddressDTO
    {

        [Required]
         public string FirstName {get; set;}

           public string? MiddleName {get; set;}

            [Required]
            public string LastName {get; set;}

             [Required]
             public string Street {get; set;}

              [Required]
              public string City {get; set;}

               [Required]
               public string Country{get; set;}

                [Required]
                public string Zipcode {get; set;}
                [Required]
                public string Phone {get; set;}
        
    }
}