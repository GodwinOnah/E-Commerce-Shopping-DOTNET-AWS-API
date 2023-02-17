using System.ComponentModel.DataAnnotations;
using core.Entities.Identity;

namespace API.Controllers
{
    public class RegisterDTO
    {
         [Required]
         public string NickName {get; set;}

          public Address Address {get; set;}

          [Required]
          [EmailAddress]
        public string Email {get; set;}
         [Required]
         [RegularExpression("^(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{7,30}$",
         ErrorMessage ="Password must contain 1 Upeercase, 1 lowercase, 1 number, 1 special character and atleast 6 characters")]
        public string Password {get; set;}

    }
}