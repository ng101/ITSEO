using InfoTrack.Domain;

namespace InfoTrack.Application
{
    public class GoogleSearchUrlBuilder : ISearchUrlBuilder
    {
        public SearchProvider SearchProvider => SearchProvider.Google;

        public string GetSearchUrl(string keywords, int offset)
        {
            var formattedKeywords = keywords.Trim().Replace(' ', '+');
            return $"https://www.google.co.uk/search?q={formattedKeywords}&start={offset}";
        }
    }
}