using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        private const string OPEN_WEATHER_API_KEY = "ac1c71d0ab3a8427549f2e3ab357c68d";

        public string GetWeather(int zipcode)
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?zip={zipcode},us&appid={OPEN_WEATHER_API_KEY}";
            string response = FetchWeatherData(apiUrl);

            // Deserialize and format the data
            var jsonData = new JavaScriptSerializer().Deserialize<dynamic>(response);
            List<string> forecasts = new List<string>();
            HashSet<string> processedDates = new HashSet<string>();

            foreach (var forecast in jsonData["list"])
            {
                string date = Convert.ToDateTime(forecast["dt_txt"]).ToString("yyyy-MM-dd");

                // Check if the date has already been processed
                if (!processedDates.Contains(date))
                {
                    processedDates.Add(date);
                    string weatherDescription = forecast["weather"][0]["description"];
                    double temperatureKelvin = Convert.ToDouble(forecast["main"]["temp"]);

                    // Convert temperature to Fahrenheit
                    double temperatureFahrenheit = (temperatureKelvin - 273.15) * 9 / 5 + 32;

                    forecasts.Add($"Date: {date}, Weather: {weatherDescription}, Temperature: {temperatureFahrenheit:0.##}°F");
                }

                if (processedDates.Count >= 5) break;
            }

            return string.Join("\n", forecasts);
        }

        private string FetchWeatherData(string apiUrl)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(apiUrl);
            }
        }
    }
}
