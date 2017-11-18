using GoogleSearchSeo.Core.Logic.Conctract;
using GoogleSearchSeo.Core.Model;
using System;

namespace GoogleSearchSeo.Core.Logic.Concrete
{
    public class ErrorMapper : IErrorMapper
    {
        /// <summary>
        /// Maps an exception to a known object of error.
        /// </summary>
        /// <param name="ex">The exception to map.</param>
        /// <returns></returns>
        public Error Map(Exception ex)
        {
            Error error = new Error();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            error.Source = ex.Source;
            return error;
        }
    }
}
