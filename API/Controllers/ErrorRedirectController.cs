using API.ErrorsHandlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorRedirectController: ApiControllerBase
    {
        public IActionResult Err(int code){
                return new ObjectResult(new Responses(code));
        }
        
    }
}