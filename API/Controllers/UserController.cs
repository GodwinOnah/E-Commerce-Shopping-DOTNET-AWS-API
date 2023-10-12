using API.ErrorsHandlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.ApiErrorMiddleWares;
using AutoMapper;
using core.Entities.Identity;
using core.Interfaces;
using API.DTOs;
using core.Entities.DTOs;

namespace API.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager,
           
         SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Use to get a new user
        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser(){  
            var user = await _userManager.FindByEmailByClaimPrinciple(User);
            return new UserDTO {
                NickName = user.NickName,
                Email = user.Email,
                Token =  _tokenService.createToken(user)
            };}

        // [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDTO>> GetAddress(){
            var user = await _userManager.FindUserByClaimsPrincipleWithAddress(User);
            return _mapper.Map<Address,AddressDTO>(user.address);
            }

      
        [HttpPut("address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO addressDTO){
            var user = await _userManager.FindUserByClaimsPrincipleWithAddress(User);
            user.address = _mapper.Map<AddressDTO,Address>(addressDTO);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded) 
            return Ok(_mapper.Map< Address,AddressDTO>(user.address));
            return BadRequest("Could not update user");
            }
        
        // Check if Email Exist
         [HttpGet("emailexist")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email){             
            return await _userManager.FindByEmailAsync(email)!=null;
        }

    
         [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO){                  
            var user = await _userManager.FindByEmailAsync(loginDTO.email);

            if(user == null) 
            return Unauthorized(new Responses(401));

            var result = await  _signInManager.CheckPasswordSignInAsync(user,loginDTO.password,false);
            
            if(!result.Succeeded) return Unauthorized(new Responses(401));
            return new UserDTO {
                NickName = user.NickName,
                Email = user.Email,
                Token =  _tokenService.createToken(user)
            };}

        [HttpPut("forgotpasswrd")]
        public async Task<ActionResult<UserDTO>> UpdatePassword(ForgotPassDetail  forgotPassDetail){  
            var user = await _userManager.FindByEmailAsync(forgotPassDetail.Email);
            if(user == null) 
            return Unauthorized(new Responses(401));    
            if(forgotPassDetail.Password1 == forgotPassDetail.Password2){
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,forgotPassDetail.Password1);
             var result = await _userManager.UpdateAsync(user);
             
            if(!result.Succeeded) return Unauthorized(new Responses(401));
            return new UserDTO {
                NickName = user.NickName,
                Email = user.Email,
                Token =  _tokenService.createToken(user)
            };
            } 
            else{
                return Unauthorized(new Responses(401));
            }}     
      
    //   Use to register a new customer
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO){  
            if(CheckEmail(registerDTO.email).Result.Value)
            {
                return new BadRequestObjectResult(
                    new ValidationErrors{Errors = 
                    new [] {"Sorry!!..Email already in use"}});
            }
             var user = new User{
                        NickName = registerDTO.nickName,
                        Email = registerDTO.email,
                        UserName = registerDTO.email,
                        address = new Address{
                                    firstName=registerDTO.firstName,
                                    middleName=registerDTO.middleName,
                                    lastName=registerDTO.lastName,
                                    street=registerDTO.street,
                                    city=registerDTO.city,
                                    country=registerDTO.country,
                                    zipcode=registerDTO.zipcode,
                                    phone=registerDTO.phone
                        }};
            if(registerDTO.password1 == registerDTO.password2){
            var result = await _userManager.CreateAsync(user, registerDTO.password1);

            if(!result.Succeeded) return Unauthorized(new Responses(401));
            return new UserDTO {
                NickName = user.NickName,
                Email = user.Email,
                Token = _tokenService.createToken(user)    
            };}
            else{
                 return Unauthorized(new Responses(401));
            }}}}