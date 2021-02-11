using InfoTrack.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InfoTrack.Tests.GetSiteSearchRanking.ParserTests
{
    public class GoogleParserTests
    {
        GoogleParser _sut;
        public GoogleParserTests()
        {
            _sut = new GoogleParser();
        }

        [Fact]
        public void ParseHtml()
        {
            var div = @"<div class=""BNeawe UPmit AP7Wnd"">anyResult</div>";
            var result = _sut.GetResults(div);
            Assert.Equal(div, result[0].Uri);
        }
    }
}
