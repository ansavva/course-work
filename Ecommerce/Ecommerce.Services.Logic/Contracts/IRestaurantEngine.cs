using Ecommerce.Services.Core.Model;

namespace Ecommerce.Services.Logic.Contracts
{
    public interface IRestaurantEngine
    {
        Restaurant GetRestaurant(int restaurantId);
    }
}
