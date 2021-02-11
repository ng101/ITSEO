using InfoTrack.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfoTrack.Application
{
    public class BingParser : IHtmlParser
    {
        public SearchProvider SearchProvider => SearchProvider.Bing;

        public List<SearchResult> GetResults(string html)
        {
            var resultLinks = new Regex(@"<\s*cite[^>]*>(.*?)<\s*/\s*cite>");
            return resultLinks.Matches(html)
                .Cast<Match>()
                .Select(sr => new SearchResult { Uri = sr.Value })
                .ToList();
        }
    }
    
}