using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Services;

namespace FFTriangleApp
{
    class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var services = ConfigureServices(config);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ConsoleApplication>().Run();
        }

        private static IServiceCollection ConfigureServices(IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();

            services.AddTransient<ITriangleRepository>(s => new TriangleRepository(configuration["filePath"]));
            services.AddTransient<ITriangleService, TriangleService>();
            services.AddTransient<ICellService, CellService>();
            services.AddTransient<ConsoleApplication>();

            return services;
        }
    }
}
