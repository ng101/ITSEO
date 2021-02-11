using InfoTrack.Domain;
using System;
using System.Text;

namespace InfoTrack.Application
{
    public interface ISearchUrlBuilderFactory
    {
        ISearchUrlBuilder GetSearchUrlBuilder(SearchProvider searchProvider);
    }
}
