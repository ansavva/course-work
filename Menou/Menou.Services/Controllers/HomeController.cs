using Microsoft.AspNetCore.Mvc;

namespace Menou.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(true);
        }
    }
}