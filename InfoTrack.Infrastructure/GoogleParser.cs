using InfoTrack.Application;
using InfoTrack.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfoTrack.Infrastructure
{
    public class GoogleParser : IHtmlParser
    {
        public SearchProvider SearchProvider => SearchProvider.Google;

        public List<SearchResult> GetResults(string html)
        {
            var resultLinks = new Regex($@"<{"div"} [^>]*class=""BNeawe UPmit AP7Wnd""[^>]*>(.*?)<\/{"div"}>");
            return resultLinks.Matches(html)
                .Cast<Match>()
                .Select(sr => new SearchResult { Uri = sr.Value })
                .ToList();
        }
    }

}