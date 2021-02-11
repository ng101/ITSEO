using InfoTrack.Application;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IPageScraperService, PageScraperService>();
            services.AddTransient<IHtmlParser, GoogleParser>();
            services.AddTransient<IHtmlParser, BingParser>();
            services.AddTransient<ISearchUrlBuilder, BingSearchUrlBuilder>();
            services.AddTransient<ISearchUrlBuilder, GoogleSearchUrlBuilder>();
            return services;
        }
    }
}
