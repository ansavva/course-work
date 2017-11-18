using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Model;
using GoogleSearchSeo.Data.Contracts;
using GoogleSearchSeo.Logic.Contracts;
using System.Collections.Generic;

namespace GoogleSearchSeo.Logic.Concrete
{
    public class GoogleSearchCoordinatorEngine : IGoogleSearchCoordinatorEngine
    {
        private readonly IGoogleSearchProxy _googleSearchProxy;
        private readonly IGoogleSearchParserEngine _googleParserEngine;
        private readonly IGoogleSearchResultRepository _googleSearchResultRepository;
        private readonly IUrlUtilityEngine _urlUtilityEngine;

        public GoogleSearchCoordinatorEngine(
            IGoogleSearchProxy googleSearchProxy, 
            IGoogleSearchParserEngine googleParserEngine,
            IGoogleSearchResultRepository googleSearchResultRepository,
            IUrlUtilityEngine urlUtilityEngine)
        {
            Guard.ThrowIfNull(googleSearchProxy, "googleSearchProxy");
            Guard.ThrowIfNull(googleParserEngine, "googleParserEngine");
            Guard.ThrowIfNull(googleSearchResultRepository, "googleSearchResultRepository");
            Guard.ThrowIfNull(urlUtilityEngine, "urlUtilityEngine");

            _googleSearchProxy = googleSearchProxy;
            _googleParserEngine = googleParserEngine;
            _googleSearchResultRepository = googleSearchResultRepository;
            _urlUtilityEngine = urlUtilityEngine;
        }

        /// <summary>
        /// Returns back a list of google search results that match the request url provided including their heading text, url, description, and
        /// position among the other valid search results.
        /// </summary>
        /// <param name="searchTerm">The search term to search for.</param>
        /// <param name="searchCount">The number of search results to retrieve.</param>
        /// <param name="matchUrl">The url to match against.</param>
        /// <returns></returns>
        public List<GoogleSearchResult> GetGoogleSearchResults(string searchTerm, int searchCount, string matchUrl)
        {
            Guard.ThrowIfEmpty(searchTerm, "searchTerm");

            List<GoogleSearchResult> googleSearchResults = 
                _googleParserEngine.ParseGoogleSearchResult(
                    _googleSearchProxy.GetGoogleSearchHtml(searchTerm, searchCount));

            int index = 1;

            List<GoogleSearchResult> googleSearchResultsToReturn =
                new List<GoogleSearchResult>();

            matchUrl = _urlUtilityEngine.GetHost(matchUrl);

            if (!string.IsNullOrEmpty(matchUrl))
            {
                for (int i = 0; i < googleSearchResults.Count; i++)
                {
                    GoogleSearchResult result = googleSearchResults[i];

                    string resultUrl = string.Empty;
                    if (!string.IsNullOrEmpty(result.ResultUrl))
                    {
                        resultUrl = _urlUtilityEngine.GetHost(result.ResultUrl);
                    }

                    // Keep search results that that have a heading, result and description populated.
                    if (!string.IsNullOrEmpty(resultUrl) &&
                        !string.IsNullOrEmpty(result.HeadingText) &&
                        !string.IsNullOrEmpty(result.Description))
                    {
                        result.Position = index;

                        // Keep the Google Search Result if they are match.
                        if (resultUrl.Contains(matchUrl))
                        {
                            result.IsMatch = true;
                        }

                        googleSearchResultsToReturn.Add(result);

                        index++;
                    }
                }
            }

            // Save all the google search results for historical record
            _googleSearchResultRepository.Create(googleSearchResultsToReturn);

            return googleSearchResultsToReturn;
        }
    }
}
