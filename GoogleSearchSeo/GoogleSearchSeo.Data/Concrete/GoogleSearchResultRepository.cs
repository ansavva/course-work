using GoogleSearchSeo.Core.Logic.Concrete;
using GoogleSearchSeo.Core.Logic.Conctract;
using GoogleSearchSeo.Core.Model;
using GoogleSearchSeo.Data.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GoogleSearchSeo.Data.Concrete
{
    public class GoogleSearchResultRepository : IGoogleSearchResultRepository 
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoClient _mongoClient = null;
        private readonly ILogger _logger;

        public GoogleSearchResultRepository(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration.Get("MongoConnectionString"));
            _logger = logger;
        }

        /// <summary>
        /// Inserts the google search results into the GoogleSearchResult collection in the GoogleSearchSeo mongo database.
        /// </summary>
        /// <param name="googleSearchResults"></param>
        public void Create(List<GoogleSearchResult> googleSearchResults)
        {
            Guard.ThrowIfNull(googleSearchResults, "googleSearchResults");

            try
            {
                //if (TestConnection())
                //{
                    _mongoClient.GetDatabase("GoogleSearchSeo")
                                .GetCollection<GoogleSearchResult>("GoogleSearchResult")
                                .InsertMany(googleSearchResults);
                //}
            }
            catch (Exception ex)
            {
                ex.Data.Add("MongoConnectionString", _configuration.Get("MongoConnectionString"));
                _logger.Error(ex, "Unable to insert document into the GoogleSearchResult collection in the GoogleSearchSeo mongo database.");
            }
        }

        /// <summary>
        /// Reads all GoogleSearchResults from the GoogleSearchResult collection in the GoogleSearchSeo mongo database.
        /// </summary>
        /// <returns></returns>
        public List<GoogleSearchResult> Read()
        {
            try
            {
                if (TestConnection())
                {
                    return _mongoClient.GetDatabase("GoogleSearchSeo")
                                       .GetCollection<GoogleSearchResult>("GoogleSearchResult")
                                       .Find(new BsonDocument())
                                       .ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("MongoConnectionString", _configuration.Get("MongoConnectionString"));
                _logger.Error(ex, "Unable to read documents from the GoogleSearchResult collection in the GoogleSearchSeo mongo database.");
            }

            return new List<GoogleSearchResult>();
        }

        /// <summary>
        /// Test if the mongo connection is up.
        /// </summary>
        /// <returns></returns>
        private bool TestConnection()
        {
            return _mongoClient.GetDatabase("GoogleSearchSeo").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
        }
    }
}
