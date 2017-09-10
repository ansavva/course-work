using Ecommerce.Core.Logic.Contracts;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;

namespace Ecommerce.Core.Logic.Concrete
{
    public class AssetEngine : IAssetEngine
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfigurationSettings _configurationSettings;

        public AssetEngine(IHostingEnvironment hostingEnvironment, IConfigurationSettings configurationSettings)
        {
            Guard.IsNotNull(hostingEnvironment, "hostingEnvironment");
            Guard.IsNotNull(configurationSettings, "configurationSettings");
            _hostingEnvironment = hostingEnvironment;
            _configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Attempts to determine the absolute path of the relative file path passed in using the system runtime.
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public string GetFilePath(string relativeFilePath)
        {
            Guard.IsNotNullOrEmpty(relativeFilePath, "relativeFilePath");

            string absoluteFilePath = string.Empty;

            string hostPath = _hostingEnvironment.ContentRootPath;

            // Try and find the absolute path using reflection (used for Tests project).
            if (string.IsNullOrEmpty(hostPath))
            {
                absoluteFilePath =
                    Path.Combine(Path.GetDirectoryName(
                        Assembly.GetEntryAssembly().Location), relativeFilePath);
            }
            // Try and find the absolute path using IIS.
            {
                absoluteFilePath = string.Format(@"{0}\{1}\{2}" , hostPath, _configurationSettings.Settings("BinDirectory"), relativeFilePath);
            }

            return absoluteFilePath ?? string.Empty;
        }
    }
}
