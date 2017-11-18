using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Logic.Conctract;
using GoogleSearchSeo.Core.Model;
using GoogleSearchSeo.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace GoogleSearchSeo.Logic.Concrete
{
    public class GoogleSearchProxy : IGoogleSearchProxy
    {
        private readonly ILogger _logger;

        public GoogleSearchProxy(ILogger logger)
        {
            Guard.ThrowIfNull(logger, "logger");
            _logger = logger;
        }

        /// <summary>
        /// Performs an http GET request for the provided search term and request count.
        /// </summary>
        /// <param name="searchTerm">The search to get google search results for.</param>
        /// <param name="requestCount">The number of serach results to retrieve.</param>
        /// <returns></returns>
        public string GetGoogleSearchHtml(string searchTerm, int requestCount)
        {
            Guard.ThrowIfEmpty(searchTerm, "searchTerm");

            List<GoogleSearchResult> googleSearchResults = new List<GoogleSearchResult>();

            try
            {
                string requestUrl = string.Format("https://www.google.com/search?num={0}&q={1}", requestCount, HttpUtility.UrlEncode(searchTerm, Encoding.UTF8));

                using (var client = new WebClient())
                {
                    // Download the google search results html document
                    client.Encoding = Encoding.UTF8;
                    return client.DownloadString(requestUrl);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unable to retrieve google html document via Http GET request.");
            }

            return string.Empty;
        }
    }
}