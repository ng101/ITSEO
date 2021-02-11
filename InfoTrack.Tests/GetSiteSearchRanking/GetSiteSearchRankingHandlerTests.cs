using InfoTrack.Application;
using InfoTrack.Domain;
using InfoTrack.Domain.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace InfoTrack.Tests
{
    public class GetSiteSearchRankingHandlerTests
    {
        GetSiteSearchRankingHandler _sut;
        Mock<IHtmlParser> SearchHtmlParserGoogleMock;
        Mock<IPageScraperService> PageScraperServiceMock;
        Mock<ISearchUrlBuilder> SearchUrlBuilderGoogleMock;

        public GetSiteSearchRankingHandlerTests()
        {
            SearchUrlBuilderGoogleMock = new Mock<ISearchUrlBuilder>();
            SearchUrlBuilderGoogleMock.SetupGet(s => s.SearchProvider).Returns(SearchProvider.Google);
            var urlBuilders = new List<ISearchUrlBuilder>();
            urlBuilders.Add(SearchUrlBuilderGoogleMock.Object);
            var searchUrlBuilderFactory = new SearchUrlBuilderFactory(urlBuilders);


            var parsers = new List<IHtmlParser>();
            SearchHtmlParserGoogleMock = new Mock<IHtmlParser>();
            SearchHtmlParserGoogleMock.SetupGet(s => s.SearchProvider).Returns(SearchProvider.Google);
            parsers.Add(SearchHtmlParserGoogleMock.Object);
            var htmlParserFactory = new HtmlParserFactory(parsers);

            PageScraperServiceMock = new Mock<IPageScraperService>();
            _sut = new GetSiteSearchRankingHandler(PageScraperServiceMock.Object, searchUrlBuilderFactory, htmlParserFactory);

        }

        [Fact]
        public void Throw_Exception_When_searchUrlBuilder_Not_Found()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var searchUrl = $"anyUrl.com/searchq={keywords}";

            var exception = Assert.ThrowsAsync<SearchUrlBuilderNotFoundException>(() => _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Bing), CancellationToken.None)).Result;

            Assert.Equal("No url builder found for provider Bing", exception.Message);
        }

        [Fact]
        public void Throw_Exception_When_Parser_Not_Found()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var searchUrl = $"anyUrl.com/searchq={keywords}";
            SearchHtmlParserGoogleMock.SetupGet(s => s.SearchProvider).Returns(SearchProvider.Bing);

            var exception = Assert.ThrowsAsync<NoParserFoundException>(() => _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Google), CancellationToken.None)).Result;

            Assert.Equal("No parser found for prover Google", exception.Message);
        }

        [Fact]
        public void Throw_Exception_When_No_Html_Returned()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var searchUrl = $"anyUrl.com/searchq={keywords}";

            var exception = Assert.ThrowsAsync<NoHtmlReturnedException>(() => _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Google), CancellationToken.None)).Result;
        }

        [Fact]
        public void Throw_Exception_When_No_Search_Results()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var searchUrl = $"anyUrl.com/searchq={keywords}";
            var anySearchUrl = "anySearchUrl";
            var anyHtml = "anyHtml";

            SearchUrlBuilderGoogleMock.Setup(s => s.GetSearchUrl(It.IsAny<string>(), It.IsAny<int>())).Returns(anySearchUrl);
            PageScraperServiceMock.Setup(p => p.GetPageHtml(anySearchUrl)).ReturnsAsync(anyHtml);
            SearchHtmlParserGoogleMock.Setup(s => s.GetResults(anyHtml)).Returns(new List<SearchResult>());

            var exception = Assert.ThrowsAsync<NoSearchResultsParsedException>(() => _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Google), CancellationToken.None)).Result;
            Assert.Equal("No search results found for provider Google for any keywords", exception.Message);            
        }


        [Fact]
        public void Return_Search_Results_with_no_match()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var anySearchUrl = "anySearchUrl";
            var anyHtml = "anyHtml";
            var unknownUri = "unknown Uri";

            SearchUrlBuilderGoogleMock.Setup(s => s.GetSearchUrl(It.IsAny<string>(), It.IsAny<int>())).Returns(anySearchUrl);
            PageScraperServiceMock.Setup(p => p.GetPageHtml(anySearchUrl)).ReturnsAsync(anyHtml);
            SearchHtmlParserGoogleMock.Setup(s => s.GetResults(anyHtml)).Returns(new List<SearchResult> { new SearchResult { Uri = unknownUri } });

            var result =  _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Google), CancellationToken.None).Result;
            Assert.Equal("0", result.SearchPosition);
        }

        [Fact]
        public void Return_Search_Results_with_matches()
        {
            var keywords = "any keywords";
            var uri = "anyUri";
            var anySearchUrl = "anySearchUrl";
            var anyHtml = "anyHtml";

            SearchUrlBuilderGoogleMock.Setup(s => s.GetSearchUrl(It.IsAny<string>(), It.IsAny<int>())).Returns(anySearchUrl);
            PageScraperServiceMock.Setup(p => p.GetPageHtml(anySearchUrl)).ReturnsAsync(anyHtml);
            SearchHtmlParserGoogleMock.Setup(s => s.GetResults(anyHtml)).Returns(new List<SearchResult> { new SearchResult { Uri = uri } });

            var result = _sut.Handle(new GetSiteSearchRankingQuery(keywords, uri, SearchProvider.Google), CancellationToken.None).Result;
            Assert.Equal("1,2,3,4,5,6,7,8,9,10", result.SearchPosition);
        }
    }
}
