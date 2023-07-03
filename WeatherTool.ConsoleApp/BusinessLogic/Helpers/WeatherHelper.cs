using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherTool.ConsoleAPP.BusinessLogic.Interfaces;
using WeatherTool.ConsoleAPP.Models;

namespace WeatherTool.ConsoleAPP.BusinessLogic.Helpers
{
    public class WeatherHelper : IWeatherHelper
    {
        public readonly IConfiguration _configuration;
        readonly HttpClient clients;
        private const string baseAPIUrl = "https://api.open-meteo.com/v1/forecast?";
        public WeatherHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            clients = new HttpClient();
        }
        public WeatherDetail GetWeatherForecast(CityDetail cityDetail)
        {
            if (cityDetail == null)
                return new WeatherDetail();

            decimal latValue;
            _ = decimal.TryParse(Convert.ToString(cityDetail.lat), out latValue);

            if (latValue <= 0)
                return new WeatherDetail();

            decimal lngValue;
            _ = decimal.TryParse(Convert.ToString(cityDetail.lat), out lngValue);

            if (lngValue <= 0)
                return new WeatherDetail();

            WeatherDetail weatherDetail = new WeatherDetail();
            string WeatherForecastAPI = string.Format("{0}latitude={1}&longitude={2}&current_weather=true", baseAPIUrl, cityDetail.lat, cityDetail.lng);
            var content = new StringContent("application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = clients.GetAsync(WeatherForecastAPI).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                weatherDetail = JsonConvert.DeserializeObject<WeatherDetail>(result);
            }

            return weatherDetail;
        }
    }
}