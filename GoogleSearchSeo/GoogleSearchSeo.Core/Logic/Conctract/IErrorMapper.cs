using GoogleSearchSeo.Core.Model;
using System;

namespace GoogleSearchSeo.Core.Logic.Conctract
{
    public interface IErrorMapper
    {
        /// <summary>
        /// Maps an exception to a known object of error.
        /// </summary>
        /// <param name="ex">The exception to map.</param>
        /// <returns></returns>
        Error Map(Exception ex);
    }
}
