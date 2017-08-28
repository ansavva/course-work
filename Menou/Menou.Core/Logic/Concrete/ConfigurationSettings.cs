using Menou.Core.Logic.Contracts;
using Microsoft.Extensions.Configuration;
using System;

namespace Menou.Core.Logic.Concrete
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly IConfiguration _configuration;

        public ConfigurationSettings(IConfiguration configuration)
        {
            Guard.IsNotNull(configuration, "configuration");
            _configuration = configuration;
        }

        /// <summary>
        /// Retrieves the configuration setting required for the application at runtime.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Settings(string key)
        {
            Guard.IsNotNullOrEmpty(key, "key");

            if (_configuration.GetSection("Data").GetSection(key).Value != null)
            {
                return _configuration.GetSection("Data").GetSection(key).Value;
            }
            else if (_configuration[key] != null)
            {
                return _configuration[key];
            }
            else
            {
                throw new Exception(string.Format("Configuration setting not found for {0}", key));
            }
        }
    }
}
