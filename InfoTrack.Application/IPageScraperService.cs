using System.Threading.Tasks;

namespace InfoTrack.Application
{
    public interface IPageScraperService
    {
        Task<string> GetPageHtml(string uri);
    }
}
