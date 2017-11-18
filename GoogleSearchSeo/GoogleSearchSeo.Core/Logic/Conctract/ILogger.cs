using System;

namespace GoogleSearchSeo.Core.Logic.Conctract
{
    public interface ILogger
    {
        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="ex">The exception to be logged.</param>
        /// <param name="message">A custom message to override the exception error message.</param>
        void Error(Exception ex, string message = null);

    }
}
