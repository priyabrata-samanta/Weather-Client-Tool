using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTool.ConsoleAPP.BusinessLogic.Interfaces;
using WeatherTool.ConsoleAPP.Models;

namespace WeatherTool.ConsoleAPP.BusinessLogic.Helpers
{
    public class CityHelper : ICityHelper
    {
        public CityDetail GetCityDetail(string cityName)
        {
            CityDetail cityDetail = new CityDetail();
            using (StreamReader r = new StreamReader("./cities.json"))
            {
                string json = r.ReadToEnd();
                var listCityDetail = JsonConvert.DeserializeObject<List<CityDetail>>(json);

                if (listCityDetail != null)
                {
                    cityDetail = listCityDetail.FirstOrDefault(t => t.city.Equals(cityName, StringComparison.OrdinalIgnoreCase));
                }
            }

            return cityDetail;
        }
    }
}