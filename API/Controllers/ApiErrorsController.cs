using API.ErrorsHandlers;
using infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApiErrorsController: ApiControllerBase
    {
        private readonly productContext _context;
        public ApiErrorsController(productContext context)
        {
            _context = context;
        }



        [HttpGet("testingauth")]
        // [Authorize]
        
        public ActionResult<string> GetSecretKey(){
                return "secret stuff";
        }
        

         [HttpGet("badrequest")]
        public ActionResult GetBadRequestError(){

            return BadRequest(new Responses(400));

        }

         [HttpGet("servererror")]
        public ActionResult GetServerError(){

             var erros=  _context.Products.Find(30);
             var serverErr=erros.ToString();

             return Ok();

        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundError(){

            var erros=  _context.Products.Find(30);
            if(erros==null){
                return NotFound(new Responses(404));
            }

            return Ok();

        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequestError(int id){

                return Ok();
        }
        
        
    }
}