using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InfoTrack.Domain.Extensions
{
    public static class StringExtentions
    {
        public static string RemoveHtmlTags(this string url)
        {
            var uri = Regex.Replace(url, "<.*?>", string.Empty);
            return uri.Trim().Replace(" ", string.Empty);
        }
    }
}
