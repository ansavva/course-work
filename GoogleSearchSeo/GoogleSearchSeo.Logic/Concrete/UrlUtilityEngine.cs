using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Logic.Contracts;
using System;

namespace GoogleSearchSeo.Logic.Concrete
{
    public class UrlUtilityEngine : IUrlUtilityEngine
    {
        /// <summary>
        /// Retrieves the host from the url provided. 
        /// Attempts to correct the url for commong mistakes such as missing http and https protocols.
        /// </summary>
        /// <param name="matchUrl"></param>
        /// <returns></returns>
        public string GetHost(string matchUrl)
        {
            Guard.ThrowIfEmpty(matchUrl, "matchUrl");

            matchUrl = matchUrl.ToLower();

            // Strip the url down to the host (ex: www.google.com)
            try
            {
                if (!matchUrl.Contains("http") || !matchUrl.Contains("https"))
                {
                    if (!matchUrl.Contains("://"))
                    {
                        matchUrl = "https://" + matchUrl;
                    }
                    else
                    {
                        matchUrl = "https" + matchUrl;
                    }
                }

                matchUrl = new Uri(matchUrl).Host;
            }
            // An invalid url was given. Remove all match and 
            // return no results.
            catch
            {
                matchUrl = string.Empty;
            }

            return matchUrl;
        }
    }
}
