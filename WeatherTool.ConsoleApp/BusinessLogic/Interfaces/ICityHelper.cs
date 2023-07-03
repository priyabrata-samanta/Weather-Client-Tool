using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTool.ConsoleAPP.Models;

namespace WeatherTool.ConsoleAPP.BusinessLogic.Interfaces
{
    public interface ICityHelper
    {
        public CityDetail GetCityDetail(string cityName);
    }
}