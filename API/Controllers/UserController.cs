using API.ErrorsHandlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.ApiErrorMiddleWares;
using AutoMapper;
using core.Entities.Identity;
using core.Interfaces;
using API.DTOs;




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
            // Console.WriteLine("\n\n\n\n"+User+"\n\n\n\n");
            var user = await _userManager.FindByEmailByClaimPrinciple(User);
            var x=user;
           Console.WriteLine("\n\n\n\n"+x+55+"\n\n\n\n");
            return new UserDTO {
                nickName = user.nickName,
                email = user.Email,
                token =  _tokenService.createToken(user)
            };}

        // [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDTO>> GetAddress(){
            var user = await _userManager.FindUserByClaimPrincipleWIthAddress(User);
            // Console.WriteLine("\n\n\n\n"+user+66+"\n\n\n\n");
            return _mapper.Map<Address,AddressDTO>(user.address);
            }

        // [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO address){
            var user = await _userManager.FindUserByClaimPrincipleWIthAddress(HttpContext.User);
            user.address = _mapper.Map<AddressDTO,Address>(address);
            var result = await _userManager.UpdateAsync(user);
            if(!result.Succeeded) return Ok(_mapper.Map<Address,AddressDTO>(user.address));
            return BadRequest("Could not update user");
            }
        
        // Check if Email Exist
         [HttpGet("emailexist")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email){             
                return await _userManager.FindByEmailAsync(email)!=null;
        }

        // Use for login
        // [Authorize]
         [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO){                  
            var user = await _userManager.FindByEmailAsync(loginDTO.email);
            if(user == null) return Unauthorized(new Responses(401));
            var result = await  _signInManager.CheckPasswordSignInAsync(user,loginDTO.password,false);
            if(!result.Succeeded) return Unauthorized(new Responses(401));
            return new UserDTO {
                nickName = user.nickName,
                email = user.Email,
                token =  _tokenService.createToken(user)
            };}
      
    //   Use to register a new customer
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO){  
            if(CheckEmail(registerDTO.Email).Result.Value)
            {
                return new BadRequestObjectResult(
                    new ValidationErrors{Errors = 
                    new [] {"Sorry!!..Email already in use"}});
            }

             var user = new User{
                        nickName = registerDTO.NickName,
                        Email = registerDTO.Email,
                        UserName = registerDTO.Email,
                            address = new Address{
                                    FirstName=registerDTO.FirstName,
                                    MiddleName=registerDTO.MiddleName,
                                    LastName=registerDTO.LastName,
                                    Street=registerDTO.Street,
                                    City=registerDTO.City,
                                    Country=registerDTO.Country,
                                    Zipcode=registerDTO.Zipcode,
                                    Phone=registerDTO.Phone
                        }};
                
            var result = await _userManager.CreateAsync(user, registerDTO.Password);       
            if(!result.Succeeded) return Unauthorized(new Responses(401));
            return new UserDTO {
                nickName = user.nickName,
                email = user.Email,
                token = _tokenService.createToken(user)    
            };}}}