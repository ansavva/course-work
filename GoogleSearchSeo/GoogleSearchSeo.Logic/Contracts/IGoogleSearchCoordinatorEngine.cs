using GoogleSearchSeo.Core.Model;
using System.Collections.Generic;

namespace GoogleSearchSeo.Logic.Contracts
{
    public interface IGoogleSearchCoordinatorEngine
    {
        /// <summary>
        /// Returns back a list of google search results that match the request url provided including their heading text, url, description, and
        /// position among the other valid search results.
        /// </summary>
        /// <param name="searchTerm">The search term to search for.</param>
        /// <param name="searchCount">The number of search results to retrieve.</param>
        /// <param name="matchUrl">The url to match against.</param>
        /// <returns></returns>
        List<GoogleSearchResult> GetGoogleSearchResults(string searchTerm, int searchCount, string matchUrl);
    }
}
