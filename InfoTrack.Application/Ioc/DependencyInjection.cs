using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InfoTrack.Application.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<ISearchUrlBuilderFactory, SearchUrlBuilderFactory>();
            services.AddTransient<IHtmlParserFactory, HtmlParserFactory>();
            return services;
        }
    }
}
