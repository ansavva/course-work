using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Logic.Conctract;
using GoogleSearchSeo.Core.Model;
using GoogleSearchSeo.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GoogleSearchSeo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoogleSearchCoordinatorEngine _googleSearchCoordinatorEngine;
        private readonly ILogger _logger;
        private readonly IErrorMapper _errorMapper;

        public HomeController(
            IGoogleSearchCoordinatorEngine googleSearchCoordinatorEngine,
            ILogger logger,
            IErrorMapper errorMapper)
        {
            Guard.ThrowIfNull(googleSearchCoordinatorEngine, "googleSearchCoordinatorEngine");
            Guard.ThrowIfNull(logger, "logger");
            Guard.ThrowIfNull(errorMapper, "errorMapper");

            _googleSearchCoordinatorEngine = googleSearchCoordinatorEngine;
            _logger = logger;
            _errorMapper = errorMapper;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retrieves the search results for the provided search term, search count, and match url.
        /// Data is returned as a JsonResult with a ServerResponse wrapped inside of it.
        /// </summary>
        /// <param name="searchTerm">The search term to search google for.</param>
        /// <param name="searchCount">The number of the search results to check against.</param>
        /// <param name="matchUrl">The url to search for in the search results retrieved from Google.</param>
        /// <returns></returns>
        public ActionResult SearchResults(string searchTerm, int searchCount, string matchUrl)
        {
            JsonResult result = new JsonResult();

            try
            {
                Guard.ThrowIfEmpty(searchTerm, "searchTerm");
                Guard.ThrowIfEmpty(matchUrl, "matchUrl");

                result.Data = new ServerResponse<List<GoogleSearchResult>>()
                {
                    Success = true,
                    Data = _googleSearchCoordinatorEngine.GetGoogleSearchResults(searchTerm, searchCount, matchUrl)
                };
            }
            catch(Exception ex)
            {
                _logger.Error(ex);

                result.Data = new ServerResponse<GoogleSearchResult>()
                {
                    Success = false,
                    Error = _errorMapper.Map(ex)
                };
            }

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}