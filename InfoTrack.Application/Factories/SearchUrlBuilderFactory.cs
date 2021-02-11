using InfoTrack.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrack.Application
{
    public class SearchUrlBuilderFactory : ISearchUrlBuilderFactory
    {
        public IEnumerable<ISearchUrlBuilder> _searchUrlBuilders { get; }

        public SearchUrlBuilderFactory(IEnumerable<ISearchUrlBuilder> searchUrlBuilders)
        {
            _searchUrlBuilders = searchUrlBuilders;
        }

        public ISearchUrlBuilder GetSearchUrlBuilder(SearchProvider searchProvider)
        {
            var searchUrlBuilder = _searchUrlBuilders.FirstOrDefault(s => s.SearchProvider == searchProvider);
            return searchUrlBuilder;
        }
    }
}
