using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using WeatherTool.ConsoleAPP.BusinessLogic.Helpers;
using WeatherTool.ConsoleAPP.BusinessLogic.Interfaces;

namespace WeatherTool.ConsoleAPP
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(AppContext.BaseDirectory))
               .AddJsonFile("appsettings.json", optional: true);

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ICityHelper, CityHelper>();
            services.AddSingleton<IWeatherHelper, WeatherHelper>();
        }
    }
}