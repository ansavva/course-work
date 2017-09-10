using Ecommerce.Core.Model;

namespace Ecommerce.Logic.Contracts.Proxies.Internal
{
    public interface IRestaurantProxyEngine
    {
        Restaurant Get(int restaurantId);
    }
}
