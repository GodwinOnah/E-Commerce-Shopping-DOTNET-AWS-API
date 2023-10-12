using core.Controllers;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductTypeController : ApiControllerBase
    {
        private readonly IProductType _productTypes;
        
        public ProductTypeController(IProductType  productTypes)
                            {     
                                _productTypes= productTypes;
                            }
        [HttpPost] 
        public async Task<ActionResult> UploadType(ProductType type)
        {
               await _productTypes.UploadTypeAsync(type);
                return Ok();             
        }          
    
        [HttpDelete("{id}")] 
        public async Task<bool> DeleteType(int id)
        {
               await _productTypes.DeleteTypeAsync(id);
                return true;             
        }  
    }
}
   