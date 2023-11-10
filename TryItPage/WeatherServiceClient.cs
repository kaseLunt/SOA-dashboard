using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;

namespace TryItPage
{
    public class WeatherServiceClient
    {
        private readonly HttpClient _httpClient;

        public WeatherServiceClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://webstrar110.fulton.asu.edu/page7/WeatherService.svc/") };
        }

        public string GetWeather(string zipcode)
        {

            var response = _httpClient.GetStringAsync($"weather-service/{zipcode}");
            return response.ToString();

        }
    }

}