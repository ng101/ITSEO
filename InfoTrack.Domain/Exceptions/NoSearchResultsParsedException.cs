using System;

namespace InfoTrack.Domain.Exceptions
{
    public class NoSearchResultsParsedException : Exception
    {
        public NoSearchResultsParsedException(SearchProvider provider, string keywords)
            : base($"No search results found for provider {provider} for {keywords}")
        {

        }
    }
}
