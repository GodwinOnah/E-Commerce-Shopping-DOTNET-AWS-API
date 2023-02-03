using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ErrorsHandlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using core.Entities.Identity;

namespace API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(UserManager<AppUser> userManager,
         SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

         [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO){
                     Console.WriteLine(5);
            var user = await _userManager.FindByEmailAsync(loginDTO.email);
           

            if(user == null) return Unauthorized(new Responses(401));

            var result = await  _signInManager.CheckPasswordSignInAsync(user,loginDTO.password,false);

            if(!result.Succeeded) return Unauthorized(new Responses(401));

            return new UserDTO {

                nickName = user.NickName,
                email = user.Email,
                token = "Token sent"
                

            };

                 
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO){

             var user = new AppUser{

                        NickName=registerDTO.nickName,
                        Email=registerDTO.email,
                        UserName=registerDTO.email
             };
                   
            var result = await _userManager.CreateAsync(user, registerDTO.password);
        
            if(!result.Succeeded) return Unauthorized(new Responses(401));

            return new UserDTO {

                nickName = user.NickName,
                email = user.Email,
                token = "Regired"
                

            };

                 
        }


    }
}