using InfoTrack.Domain;
using System.Collections.Generic;

namespace InfoTrack.Application
{
    public interface IHtmlParser
    {
        SearchProvider SearchProvider { get; }

        List<SearchResult> GetResults(string html);
    }
}