using Microsoft.Extensions.DependencyInjection;
using SearchEngine;
using SearchEngine.Helpers;
using System;

namespace SearchfightApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ClientApp>().Run(args);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ISearchEngineFactory, SearchEngineFactory>();
            services.AddTransient<ClientApp>();
            return services;
        }
    }
}
