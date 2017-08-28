using Menou.Core.Model;

namespace Menou.Logic.Contracts.Proxies.Internal
{
    public interface IRestaurantProxyEngine
    {
        Restaurant Get(int restaurantId);
    }
}
