using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ErrorsHandlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using core.Entities.Identity;
using core.Interfaces;

namespace API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public UserController(UserManager<AppUser> userManager,
        
         SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

         [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO){
                   
            var user = await _userManager.FindByEmailAsync(loginDTO.email);
           

            if(user == null) return Unauthorized(new Responses(401));

            var result = await  _signInManager.CheckPasswordSignInAsync(user,loginDTO.password,false);

            if(!result.Succeeded) return Unauthorized(new Responses(401));

            return new UserDTO {

                nickName = user.NickName,
                email = user.Email,
                token =  _tokenService.createToken(user)
                

            };

                 
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO){

             var user = new AppUser{

                        NickName = registerDTO.nickName,
                        Email = registerDTO.email,
                        UserName = registerDTO.email
             };
                   
            var result = await _userManager.CreateAsync(user, registerDTO.password);
        
            if(!result.Succeeded) return Unauthorized(new Responses(401));

            return new UserDTO {

                nickName = user.NickName,
                email = user.Email,
                token = _tokenService.createToken(user)
                

            };

                 
        }


    }
}