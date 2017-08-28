using Menou.Core.Logic.Concrete;
using Menou.Logic.Contracts.Proxies.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Menou.Controllers
{
    public class MenuController : Controller
    {
        private readonly IRestaurantProxyEngine _restaurantProxyEngine;

        public MenuController(IRestaurantProxyEngine restaurantProxyEngine)
        {
            Guard.IsNotNull(restaurantProxyEngine, "restaurantProxyEngine");
            _restaurantProxyEngine = restaurantProxyEngine;
        }

        //GET: Menu/Index
        public IActionResult Index()
        {
            return View(_restaurantProxyEngine.Get(1));
        }
    }
}