using Ecommerce.Services.Core.Logic.Concrete;
using Ecommerce.Services.Core.Model;
using Ecommerce.Services.Data.Contracts.dbo.Ecommerce;
using Ecommerce.Services.Logic.Contracts;

namespace Ecommerce.Services.Logic.Concrete
{
    public class RestaurantEngine : IRestaurantEngine
    {
        private readonly IRestaurantRepository _restaurantRepo;
        private readonly IMenuItemRepository _menuItemRepo;

        public RestaurantEngine(IRestaurantRepository restaurantRepo, IMenuItemRepository menuItemRepo)
        {
            Guard.IsNotNull(restaurantRepo, "restaurantRepo");
            Guard.IsNotNull(menuItemRepo, "menuItemRepo");
            _restaurantRepo = restaurantRepo;
            _menuItemRepo = menuItemRepo;
        }

        /// <summary>
        /// Get the restaurant and its menu item for the restaurant id specified.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = _restaurantRepo.ReadRestaurant(restaurantId);
            restaurant.MenuItems = _menuItemRepo.ReadMenuItems(restaurantId);
            return restaurant;
        }
    }
}
