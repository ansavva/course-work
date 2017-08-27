using Menou.Services.Core.Logic.Concrete;
using Menou.Services.Core.Model;
using Menou.Services.Logic.Contracts;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Menou.Services.Controllers
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

        // GET api/values/5
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