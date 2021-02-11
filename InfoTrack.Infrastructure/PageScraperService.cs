using InfoTrack.Application;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrack.Infrastructure
{
    public class PageScraperService : IPageScraperService
    {
        private readonly HttpClient _client;

        public PageScraperService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetPageHtml(string uri)
        {
            var response = await _client.GetAsync(uri);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
