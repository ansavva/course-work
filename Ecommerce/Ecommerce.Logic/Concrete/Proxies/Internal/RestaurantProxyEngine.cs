using Ecommerce.Core.Logic.Concrete;
using Ecommerce.Core.Logic.Contracts;
using Ecommerce.Core.Model;
using Ecommerce.Logic.Contracts.Proxies.Internal;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Ecommerce.Logic.Concrete.Proxies.Internal
{
    public class RestaurantProxyEngine : IRestaurantProxyEngine
    {
        private readonly IConfigurationSettings _configurationSettings;

        public RestaurantProxyEngine(IConfigurationSettings configurationSettings)
        {
            Guard.IsNotNull(configurationSettings, "configurationSettings");
            _configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Get the restaurant and its menu item for the restaurant id specified.
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant Get(int restaurantId)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(_configurationSettings.Settings("ServiceHost")),
                Timeout = new TimeSpan(0, 5, 0)
            };
            HttpResponseMessage response = client.GetAsync(string.Format("/api/Restaurant/{0}", restaurantId)).Result;
            ServiceResponse<Restaurant> serviceResponse = 
                JsonConvert.DeserializeObject<ServiceResponse<Restaurant>>(
                    response.Content.ReadAsStringAsync().Result);
            if (serviceResponse.Success)
            {
                return serviceResponse.Data;
            }
            else
            {
                return new Restaurant();
            }
        }
    }
}
