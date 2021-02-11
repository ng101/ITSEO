using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Domain.Exceptions
{
    public class SearchUrlBuilderNotFoundException : Exception
    {
        public SearchUrlBuilderNotFoundException(SearchProvider provider)
            : base($"No url builder found for provider {provider}")
        {

        }
    }
}
