using Menou.Services.Core.Model;

namespace Menou.Services.Data.Contracts.dbo.Menou
{
    public interface IRestaurantRepository
    {
        Restaurant ReadRestaurant(int restaurantId);
    }
}
