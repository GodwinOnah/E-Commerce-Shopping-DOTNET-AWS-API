using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FallbackController : Controller
    {
       public IActionResult index() {
            return PhysicalFile
    (Path.Combine(Directory.GetCurrentDirectory(),
    "wwwroot", "index.html"), "text/HTML");

       }
    }
}