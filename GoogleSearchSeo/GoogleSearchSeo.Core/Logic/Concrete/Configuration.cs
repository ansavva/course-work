using GoogleSearchSeo.Core.Logic.Conctract;
using System.Configuration;
using System.Linq;

namespace GoogleSearchSeo.Core.Logic.Concrete
{
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// Retrieves the the value of the key provided from the app settings 
        /// of the configuration file.
        /// </summary>
        /// <param name="key">The key to retrieve the corresponding value for.</param>
        /// <returns></returns>
        public string Get(string key)
        {
            Guard.ThrowIfEmpty(key, "key");

            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                return ConfigurationManager.AppSettings[key];
            }

            return string.Empty;
        }
    }
}
