using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Model;
using GoogleSearchSeo.Logic.Contracts;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GoogleSearchSeo.Logic.Concrete
{
    public class GoogleSearchParserEngine : IGoogleSearchParserEngine
    {
        /// <summary>
        /// Parses the google result html document into a list of Google Search Results.
        /// </summary>
        /// <param name="searchResultHtmlDocument">The html document retrieved from google search.</param>
        /// <returns></returns>
        public List<GoogleSearchResult> ParseGoogleSearchResult(string searchResultHtmlDocument)
        {
            Guard.ThrowIfEmpty(searchResultHtmlDocument, "searchResultHtmlDocument");

            List<GoogleSearchResult> googleSearchResults = new List<GoogleSearchResult>();

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(searchResultHtmlDocument);

            // Load the html document into Html Agility Pack so that we can parse it
            List<HtmlNode> searchResultNodes = 
                htmlDocument.DocumentNode.Descendants().Where(d => HasClassName(d, "g")).ToList();

            foreach(HtmlNode node in searchResultNodes)
            {
                GoogleSearchResult searchResult = new GoogleSearchResult();

                // Get the heading from the html document.
                HtmlNode headingNode = node.Descendants().Where(h => HasClassName(h, "r")).FirstOrDefault();

                if (headingNode != null)
                {
                    HtmlNode headingAnchorNode = headingNode.ChildNodes.FirstOrDefault();

                    if (headingAnchorNode != null)
                    {
                        searchResult.HeadingText = HttpUtility.HtmlDecode(headingAnchorNode.InnerText);
                    }
                }

                // Get the search result body
                HtmlNode bodyNode = node.Descendants().Where(h => HasClassName(h, "s")).FirstOrDefault();

                if (bodyNode != null)
                {
                    // Get the search result url
                    HtmlNode citeNode = bodyNode.Descendants("cite").FirstOrDefault();

                    if (citeNode != null)
                    {
                        searchResult.ResultUrl = HttpUtility.HtmlDecode(citeNode.InnerText.ToLower());
                    }

                    // Get the search result description
                    HtmlNode descriptionNode = bodyNode.Descendants("span").Where(s => HasClassName(s, "st")).FirstOrDefault();

                    if (descriptionNode != null)
                    {
                        searchResult.Description = HttpUtility.HtmlDecode(descriptionNode.InnerText);
                    }
                }

                googleSearchResults.Add(searchResult);
            }

            return googleSearchResults;
        }

        /// <summary>
        /// Checks in the passed in node for the class name provided. 
        /// </summary>
        /// <param name="node">The node to be tested for the class name.</param>
        /// <param name="className">The class name to search for.</param>
        /// <returns></returns>
        private bool HasClassName(HtmlNode node, string className)
        {
            Guard.ThrowIfEmpty(className, "className");
            return node.Attributes["class"] != null && node.Attributes["class"].Value == className;
        }
    }
}
