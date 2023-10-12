using Microsoft.AspNetCore.Identity;

namespace core.Entities.Identity
{
    public class User : IdentityUser
    {
        public string NickName {get; set;}
         public Address address {get; set;}    
    }   
}