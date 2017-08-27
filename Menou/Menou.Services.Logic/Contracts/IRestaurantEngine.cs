using Menou.Services.Core.Model;

namespace Menou.Services.Logic.Contracts
{
    public interface IRestaurantEngine
    {
        Restaurant GetRestaurant(int restaurantId);
    }
}
