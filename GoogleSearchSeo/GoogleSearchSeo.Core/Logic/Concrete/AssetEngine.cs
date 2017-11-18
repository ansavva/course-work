using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Logic.Conctract;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace GoogleSearchSeo.Core.Logic.Concrete
{
    public class AssetEngine : IAssetEngine
    {
        private readonly IConfiguration _configuration;

        public AssetEngine(IConfiguration configuration)
        {
            Guard.ThrowIfNull(configuration, "configuration");
            _configuration = configuration;
        }

        /// <summary>
        /// Attempts to determine the absolute path of the relative file path passed in using the system runtime.
        /// </summary>
        /// <param name="relativeFilePath"></param>
        /// <returns></returns>
        public string GetFilePath(string relativeFilePath)
        {
            Guard.ThrowIfEmpty(relativeFilePath, "relativeFilePath");

            string absoluteFilePath = string.Empty;

            string hostPath = HostingEnvironment.ApplicationPhysicalPath;

            // Try and find the absolute path using reflection (used for Tests project).
            if (string.IsNullOrEmpty(hostPath))
            {
                absoluteFilePath =
                    Path.Combine(Path.GetDirectoryName(
                        Assembly.GetEntryAssembly().Location), relativeFilePath);
            }
            // Try and find the absolute path using IIS.
            {
                absoluteFilePath = string.Format(@"{0}{1}\{2}", hostPath, _configuration.Get("BinDirectory"), relativeFilePath);
            }

            return absoluteFilePath ?? string.Empty;
        }
    }
}
