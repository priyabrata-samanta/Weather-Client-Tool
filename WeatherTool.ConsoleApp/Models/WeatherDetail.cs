using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTool.ConsoleAPP.Models
{
    public class WeatherDetail
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public decimal generationtime_ms { get; set; }
        public Int32 utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public string elevation { get; set; }
        public CurrentWeather current_weather { get; set; }
    }

    public class CurrentWeather
    {
        public decimal temperature { get; set; }
        public decimal windspeed { get; set; }
        public decimal winddirection { get; set; }
        public Int32 weathercode { get; set; }
        public Int32 is_day { get; set; }
        public DateTime time { get; set; }
    }
}