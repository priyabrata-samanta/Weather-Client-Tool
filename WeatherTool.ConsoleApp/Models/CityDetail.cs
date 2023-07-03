﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTool.ConsoleAPP.Models
{
    public class CityDetail
    {
        public string city { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string admin_name { get; set; }
        public string capital { get; set; }
        public string population { get; set; }
        public string population_proper { get; set; }
    }
}