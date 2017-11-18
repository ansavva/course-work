using GoogleSearchSeo.Core.Logic.Conctract;
using System;
using System.IO;
using System.Text;

namespace GoogleSearchSeo.Core.Logic.Concrete
{
    public class Logger : ILogger
    {
        private readonly IConfiguration _configuration;
        private readonly IAssetEngine _assetEngine;

        public Logger(IConfiguration configuration, IAssetEngine assetEngine)
        {
            Guard.ThrowIfNull(configuration, "configuration");
            Guard.ThrowIfNull(assetEngine, "assetEngine");
            _configuration = configuration;
            _assetEngine = assetEngine;
        }

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        /// <param name="message">A custom message to override the exception error message.</param>
        public void Error(Exception ex, string message = null)
        {
            try
            {
                Guard.ThrowIfNull(ex, "ex");

                string errorLogFile = _assetEngine.GetFilePath(_configuration.Get("ErrorLogFile"));

                if (!string.IsNullOrEmpty(errorLogFile))
                {
                    if (!File.Exists(errorLogFile))
                    {
                        File.Create(errorLogFile);
                    }

                    StringBuilder error = new StringBuilder();
                    error.AppendLine(DateTime.Now.ToString());
                    if (!string.IsNullOrEmpty(message))
                    {
                        error.AppendLine(message);
                    }
                    error.AppendLine(ex.Message);
                    error.AppendLine(ex.Source);
                    error.AppendLine(ex.StackTrace.ToString());
                    error.AppendLine("----------------------------------------------------------------------------");

                    File.AppendAllText(errorLogFile, error.ToString());
                }
            }
            catch
            {
                // If an exception occures when trying to log an error
                // simply eat the error. 
            }
        }
    }
}
