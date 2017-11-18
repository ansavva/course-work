using GoogleSearchSeo.Core.Model;
using System.Collections.Generic;

namespace GoogleSearchSeo.Logic.Contracts
{
    public interface IGoogleSearchProxy
    {
        /// <summary>
        /// Retrieves google search results html.
        /// </summary>
        /// <param name="searchTerm">The search term to send to google.</param>
        /// <param name="requestCount">The number of search results to retrieve.</param>
        /// <returns></returns>
        string GetGoogleSearchHtml(string searchTerm, int requestCount);
    }
}
