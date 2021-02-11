using InfoTrack.Application.Queries;
using InfoTrack.Domain;

namespace InfoTrack.Application
{
    public class GetSiteSearchRankingQuery:IQuery<SeoSearchResponse>
    {
        public GetSiteSearchRankingQuery(string keywords, string uri, SearchProvider searchProvider)
        {
            Keywords = keywords;
            Uri = uri;
            SearchProvider = searchProvider;
        }

        public string Keywords { get; private set; }
        public string Uri { get; private set; }
        public SearchProvider SearchProvider { get; private set; }
    }
}