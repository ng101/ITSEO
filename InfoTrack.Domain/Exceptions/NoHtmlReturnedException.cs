using System;

namespace InfoTrack.Domain.Exceptions
{
    public class NoHtmlReturnedException : Exception
    {
        public NoHtmlReturnedException(SearchProvider provider, string url)
            : base($"No html returned for provider {provider} for {url}")
        {

        }
    }
}
