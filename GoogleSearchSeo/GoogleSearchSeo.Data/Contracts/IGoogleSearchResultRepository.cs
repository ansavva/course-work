using GoogleSearchSeo.Core.Model;
using System.Collections.Generic;

namespace GoogleSearchSeo.Data.Contracts
{
    public interface IGoogleSearchResultRepository
    {
        void Create(List<GoogleSearchResult> googleSearchResults);
        List<GoogleSearchResult> Read();
    }
}
