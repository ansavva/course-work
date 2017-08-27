using Menou.Services.Core.Logic.Contracts;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;

namespace Menou.Services.Core.Logic.Concrete
{
    public class AssetEngine : IAssetEngine
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public AssetEngine(IHostingEnvironment hostingEnvironment)
        {
            Guard.IsNotNull(hostingEnvironment, "hostingEnvironment");
            _hostingEnvironment = hostingEnvironment;
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

            string hostPath = _hostingEnvironment.WebRootPath;

            // Try and find the absolute path using reflection (used for Tests project).
            if (string.IsNullOrEmpty(hostPath))
            {
                absoluteFilePath =
                    Path.Combine(Path.GetDirectoryName(
                        Assembly.GetEntryAssembly().Location), relativeFilePath);
            }
            // Try and find the absolute path using IIS.
            {
                absoluteFilePath = string.Format(@"{bin\{1}", hostPath, relativeFilePath);
            }

            return absoluteFilePath ?? string.Empty;
        }
    }
}
