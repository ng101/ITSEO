using InfoTrack.Application.Queries;
using InfoTrack.Domain;
using InfoTrack.Domain.Exceptions;
using InfoTrack.Domain.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrack.Application
{
    public class GetSiteSearchRankingHandler
        : IQueryHandler<GetSiteSearchRankingQuery, SeoSearchResponse>
    {
        private IPageScraperService _pageScraperService;
        private ISearchUrlBuilderFactory _searchUrlBuilderFactory;
        private IHtmlParserFactory _htmlParserFactory;
        public GetSiteSearchRankingHandler(IPageScraperService pageScraperService, ISearchUrlBuilderFactory searchUrlBuilderFactory, IHtmlParserFactory htmlParserFactory)
        {
            _pageScraperService = pageScraperService;
            _searchUrlBuilderFactory = searchUrlBuilderFactory;
            _htmlParserFactory = htmlParserFactory;
        }
               
        public async Task<SeoSearchResponse> Handle(GetSiteSearchRankingQuery request, CancellationToken cancellationToken)
        {
            var searchUrlBuilder = _searchUrlBuilderFactory.GetSearchUrlBuilder(request.SearchProvider);
            if (searchUrlBuilder == null) {
                throw new SearchUrlBuilderNotFoundException(request.SearchProvider);
            }

            var htmlParser = _htmlParserFactory.GetHtmlParserBySearchProvider(request.SearchProvider);
            if (htmlParser == null)
            {
                throw new NoParserFoundException(request.SearchProvider);
            }

            var searchResults = new List<SearchResult>();
            var offset = 0;
            while (offset < 100)
            {
                var searchUrl = searchUrlBuilder.GetSearchUrl(request.Keywords, offset);
                var html = await _pageScraperService.GetPageHtml(searchUrl);

                if (html == null || html.Length == 0)
                {
                    throw new NoHtmlReturnedException(request.SearchProvider, searchUrl);
                }

                searchResults.AddRange(htmlParser.GetResults(html));
                offset += 10;
            }

            if (searchResults.Count == 0)
            {
                throw new NoSearchResultsParsedException(request.SearchProvider, request.Keywords);
            }

            var searchPositions = searchResults.Select((result, index) => new { result, searchPosition = index + 1 })
               .Where(r => r.result.Uri.RemoveHtmlTags().Contains(request.Uri))
               .Select(p => p.searchPosition)
               .ToArray();
                  
            var response = new SeoSearchResponse { 
                SearchPosition = searchPositions.Length == 0 ? "0" : string.Join(',', searchPositions) 
            };

            return response;
        }
    }
}
