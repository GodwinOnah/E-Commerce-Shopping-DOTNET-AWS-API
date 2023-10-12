using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Identity
{
    public class IdentityUserData
    {
        public static async Task SeedUserAsync(UserManager<User> userManager){
                if(!userManager.Users.Any())
                {
                    var user1 = new User{
                        NickName="Godwin1",
                        Email="godwinbillions@gmail.com",
                        UserName="Godwin",
                        address = new Address{
                            firstName="Godwin",
                            middleName="Obande",
                            lastName="Onah",
                            street="Crow Road",
                            city="Glasgow",
                            country="United Kingdom",
                            zipcode="G117TS",
                            phone="+447751776483",
                        }
                    };
                    await userManager.CreateAsync(user1,"Gut101@@");
              }
        }
    }
}