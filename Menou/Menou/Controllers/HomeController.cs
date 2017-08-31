using Microsoft.AspNetCore.Mvc;

namespace Menou.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}