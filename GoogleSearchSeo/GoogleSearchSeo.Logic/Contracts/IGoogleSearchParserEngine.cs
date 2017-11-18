using GoogleSearchSeo.Core.Model;
using System.Collections.Generic;

namespace GoogleSearchSeo.Logic.Contracts
{
    public interface IGoogleSearchParserEngine
    {
        /// <summary>
        /// Parses the htlm document into a list of google search results.
        /// </summary>
        /// <param name="searchResultHtmlDocument">The html document to be parsed.</param>
        /// <returns></returns>
        List<GoogleSearchResult> ParseGoogleSearchResult(string searchResultHtmlDocument);
    }
}
