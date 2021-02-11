using InfoTrack.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrack.Application
{
    public class HtmlParserFactory : IHtmlParserFactory
    {
        public IEnumerable<IHtmlParser> _htmlParsers;

        public HtmlParserFactory(IEnumerable<IHtmlParser> htmlParsers)
        {
            _htmlParsers = htmlParsers;
        }


        public IHtmlParser GetHtmlParserBySearchProvider(SearchProvider searchProvider)
        {
            return _htmlParsers.FirstOrDefault(h => h.SearchProvider == searchProvider);
        }
    }
}