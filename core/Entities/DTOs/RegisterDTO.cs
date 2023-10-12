using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class RegisterDTO
    {
        [Required]
        public string nickName {get; set;}       
        [Required]
         public string firstName {get; set;}
           public string middleName {get; set;}
            [Required]
            public string lastName {get; set;}
             [Required]
             public string street {get; set;}
              [Required]
              public string city {get; set;}
               [Required]
               public string country{get; set;}
                [Required]
                public string zipcode {get; set;}
                [Required]
                public string phone {get; set;}
                [Required]
                [EmailAddress]
                public string email {get; set;}
                [Required]
                [RegularExpression("^(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{7,30}$",
                ErrorMessage ="Password must contain 1 Upeercase, 1 lowercase, 1 number, 1 special character and atleast 6 characters")]
                public string password1 {get; set;}
                 [Required]
                [RegularExpression("^(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{7,30}$",
                ErrorMessage ="Password must contain 1 Upeercase, 1 lowercase, 1 number, 1 special character and atleast 6 characters")]
                public string password2 {get; set;}


    }
}