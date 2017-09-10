using Ecommerce.Services.Core.Logic.Concrete;
using Ecommerce.Services.Core.Model;
using Ecommerce.Services.Logic.Contracts;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantEngine _restaurantEngine;

        public RestaurantController(IRestaurantEngine restaurantEngine)
        {
            Guard.IsNotNull(restaurantEngine, "restaurantEngine");
            _restaurantEngine = restaurantEngine;
        }

        // GET api/restaurant/5
        [HttpGet("{id}")]
        public ServiceResponse<Restaurant> Get(int id)
        {
            return new ServiceResponse<Restaurant>()
            {
                Success = true,
                Data = _restaurantEngine.GetRestaurant(id)
            };
        }
    }
}