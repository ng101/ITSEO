using System;

namespace InfoTrack.Domain.Exceptions
{
    public class NoParserFoundException : Exception
    {
        public NoParserFoundException(SearchProvider provider)
            : base($"No parser found for prover {provider}")
        {

        }
    }
}
