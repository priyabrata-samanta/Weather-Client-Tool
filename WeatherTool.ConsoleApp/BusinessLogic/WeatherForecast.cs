using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTool.ConsoleAPP.BusinessLogic.Interfaces;
using WeatherTool.ConsoleAPP.Models;

namespace WeatherTool.ConsoleAPP.BusinessLogic
{
    class WeatherForecast
    {
        private readonly IServiceProvider serviceProvider;
        public WeatherForecast(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        public WeatherDetail InitiateWeatherForecast(string cityName, ref string returnMessage)
        {
            CityDetail cityDetail;
            var cityService = serviceProvider.GetService<ICityHelper>();

            if (cityService == null)
            {
                GetFormattedMessage(ref returnMessage, "Something happend wrong at the time of cityService creation!!!");
                return new WeatherDetail();
            }

            cityDetail = cityService.GetCityDetail(cityName);
            if (cityDetail == null || string.IsNullOrEmpty(cityDetail.city))
            {
                GetFormattedMessage(ref returnMessage, "Provided city not available!!!");
                return new WeatherDetail();
            }

            var weatherService = serviceProvider.GetService<IWeatherHelper>();

            if (weatherService == null)
            {
                GetFormattedMessage(ref returnMessage, "Something happend wrong at the time of weatherService creation!!!");
                return new WeatherDetail();
            }

            return weatherService.GetWeatherForecast(cityDetail);
        }

        private void GetFormattedMessage(ref string returnMessage, string message)
        {
            if (!string.IsNullOrEmpty(returnMessage))
            {
                returnMessage = string.Concat(returnMessage, "\n", message);
            }
            else
            {
                returnMessage = message;
            }
        }
    }
}