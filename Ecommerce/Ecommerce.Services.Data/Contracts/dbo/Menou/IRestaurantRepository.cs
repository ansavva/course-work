using Ecommerce.Services.Core.Model;

namespace Ecommerce.Services.Data.Contracts.dbo.Ecommerce
{
    public interface IRestaurantRepository
    {
        Restaurant ReadRestaurant(int restaurantId);
    }
}
