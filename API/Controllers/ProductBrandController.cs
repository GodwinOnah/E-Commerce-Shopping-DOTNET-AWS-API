using AutoMapper;
using core.Controllers;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductBrandController : ApiControllerBase
    {

        private readonly IProductBrand _productBrands;
         private readonly IMapper _imapper;

        public ProductBrandController(IProductBrand productBrands)
                            {     
                                _productBrands = productBrands;
                            }
        [HttpPost] 
        public async Task<ActionResult> UploadBrand(ProductBrand brand)
        {
               await  _productBrands.UploadBrandAsync(brand);
                return Ok();             
        }          
    
        [HttpDelete("{id}")] 
        public async Task<bool> DeleteBrand(int id)
        {
               await _productBrands.DeleteBrandAsync(id);
                return true;             
        }  
    }
}