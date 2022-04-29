
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Instituto.Extensions;
using Npgsql;

namespace Instituto
{
    class Program
    {

        public static IServiceProvider Services { get; set; }

        public static void Main()
        {

            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            Services = serviceCollection.BuildServiceProvider();

            Startup startup = new Startup(Services.GetRequiredService<IApplication>());

            startup.IniciarApp();

        }
        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            serviceCollection.AddSingleton<ILoggerFactory>(loggerFactory);

            serviceCollection.ConfigureAppServices();

            serviceCollection.AddSingleton<IApplication, Application>();

        }

    }
}
