using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherTool.ConsoleAPP;
using WeatherTool.ConsoleAPP.BusinessLogic;
using WeatherTool.ConsoleAPP.BusinessLogic.Helpers;

namespace WeatherTool.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string cityName = string.Empty;

            //Console.WriteLine("Enter City Name:");
            //cityName = Console.ReadLine();

            if (args != null && args.Length > 0)
            {
                cityName = args[0];
            }
            else
            {
                Console.WriteLine("Please provide city name:");
                return;
            }

            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            WeatherForecast _weatherForecast = new WeatherForecast(serviceProvider);

            //Remove whitespace
            if (cityName != null)
            {
                cityName = cityName.Trim();
            }

            if (string.IsNullOrEmpty(cityName))
            {
                Console.WriteLine("You have provided blank city name!!! Please provide valid city name");
                return;
            }

            var returnMessage = string.Empty;
            var weatherForecast = _weatherForecast.InitiateWeatherForecast(cityName, ref returnMessage);

            if (string.IsNullOrEmpty(returnMessage) && weatherForecast != null && weatherForecast.current_weather != null)
            {
                Console.WriteLine($"Temperature: {weatherForecast.current_weather.temperature}");
                Console.WriteLine($"Windspeed: {weatherForecast.current_weather.windspeed}");
                Console.WriteLine($"Wind Direction: {weatherForecast.current_weather.winddirection}");
                Console.WriteLine($"Time: {weatherForecast.current_weather.time}");
            }
            else
            {
                Console.WriteLine(returnMessage);
            }
        }
    }
}
