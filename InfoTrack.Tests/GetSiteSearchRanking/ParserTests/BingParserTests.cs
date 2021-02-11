using InfoTrack.Application;
using InfoTrack.Infrastructure;
using Xunit;

namespace InfoTrack.Tests.GetSiteSearchRanking.ParserTests
{
    public class BingParserTests
    {
        BingParser _sut;
        public BingParserTests()
        {
            _sut = new BingParser();
        }

        [Fact]
        public void ParseHtml()
        {
            var div = @"<cite> anyResult </cite>";
            var result = _sut.GetResults(div);
            Assert.Equal(div, result[0].Uri);
        }
    }
}
