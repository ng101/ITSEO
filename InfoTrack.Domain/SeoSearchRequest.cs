namespace InfoTrack.Domain
{
    public class SeoSearchRequest {
        public string Keywords { get; set; }
        public SearchProvider SearchProvider { get; set; }
        public string  Url { get; set; }
    }
}