using InfoTrack.Domain;

namespace InfoTrack.Application
{
    public interface ISearchUrlBuilder
    {
        SearchProvider SearchProvider { get; }

        string GetSearchUrl(string keywords, int offset);
        
    }
}