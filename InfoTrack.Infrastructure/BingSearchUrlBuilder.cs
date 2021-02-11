using InfoTrack.Domain;

namespace InfoTrack.Application
{
    public class BingSearchUrlBuilder : ISearchUrlBuilder
    {
        public SearchProvider SearchProvider => SearchProvider.Bing;

        public string GetSearchUrl(string keywords, int offset)
        {
            var formattedKeywords = keywords.Trim().Replace(' ', '+');
            return $"https://www.bing.com/search?q={formattedKeywords}&count=10&first={offset}&form=QBRE";
        }
    }
}