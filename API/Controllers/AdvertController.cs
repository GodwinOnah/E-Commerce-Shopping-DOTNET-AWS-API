using AutoMapper;
using core.Entities.Adverts;
using core.Interfaces;
using infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdvertController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdvert _adverts;
        productContext _context;
        public AdvertController(
            IAdvert adverts,
            IMapper mapper,
            productContext context)
        {
            _adverts = adverts;
             _mapper = mapper;
            _context= context;
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<IReadOnlyList<Adverts>>> GetAvertsById(int id){
                     
            return  Ok(await  _adverts.GetAdvertsById(id)); 
        }

        [HttpGet]
         public async Task<ActionResult<IReadOnlyList<Adverts>>> GetAverts(){        
            return Ok(await  _adverts.GetAdverts());
        }

        [HttpDelete("{id}")]
         public async Task<bool> DeleteAverts(int id){ 
            
            await  _adverts.DeleteAverts(id); 
            return true;     
        } 

        [HttpPost] 
        public async Task<ActionResult> UploadProductsUrlToDb(Adverts advert)
        {      
           await  _adverts.UploadProductsUrlToDb(advert)  ;  
            return Ok();
    }
}}