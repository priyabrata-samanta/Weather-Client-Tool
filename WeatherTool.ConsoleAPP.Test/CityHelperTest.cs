using Moq;
using System;
using WeatherTool.ConsoleAPP.BusinessLogic.Helpers;
using WeatherTool.ConsoleAPP.BusinessLogic.Interfaces;
using WeatherTool.ConsoleAPP.Models;
using Xunit;

namespace WeatherTool.ConsoleAPP.Test
{
    public class CityHelperTest
    {
        private readonly Mock<ICityHelper> _mockCityHelper;
        private readonly CityHelper cityHelper;

        public CityHelperTest()
        {
            _mockCityHelper = new Mock<ICityHelper>();
            cityHelper = new CityHelper();
        }

        [Fact(DisplayName = "GetCityDetail Returns City Details"), Trait("Category", "Unit")]
        public void GetCityDetail_Returns_CityDetail()
        {
            //Arrange
            string cityName = "Kolkata";

            var cityDetail = new CityDetail()
            {
                city = "Delhi",
                lat = Convert.ToDecimal(28.6100),
                lng = Convert.ToDecimal(77.2300),
                country = "India",
                iso2 = "IN",
                admin_name = "Delhi",
                capital = "admin",
                population = "32226000",
                population_proper = "16753235"
            };

            _mockCityHelper
                .Setup(x => x.GetCityDetail(cityName))
                .Returns(cityDetail);

            var result = cityHelper.GetCityDetail(cityName);

            Assert.Equal(cityName, result.city);
        }

        [Fact(DisplayName = "GetCityDetail Returns Null"), Trait("Category", "Unit")]
        public void GetCityDetail_Returns_Null()
        {
            //Arrange
            string cityName = "ABCD";

            var cityDetail = new CityDetail()
            {
                city = "Delhi",
                lat = Convert.ToDecimal(28.6100),
                lng = Convert.ToDecimal(77.2300),
                country = "India",
                iso2 = "IN",
                admin_name = "Delhi",
                capital = "admin",
                population = "32226000",
                population_proper = "16753235"
            };

            _mockCityHelper
                .Setup(x => x.GetCityDetail(cityName))
                .Returns(cityDetail);

            var result = cityHelper.GetCityDetail(cityName);

            Assert.Null(result);
        }
    }
}