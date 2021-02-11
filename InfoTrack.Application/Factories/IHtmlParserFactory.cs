using InfoTrack.Domain;

namespace InfoTrack.Application
{
    public interface IHtmlParserFactory
    {
        IHtmlParser GetHtmlParserBySearchProvider(SearchProvider searchProvider);
    }
}