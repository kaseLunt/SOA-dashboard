using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        public async Task<string> GetWeather(int zipcode)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set the base URL for the weather API
                    string baseUrl = "https://weatherapi-com.p.rapidapi.com/current.json";

                    // Construct the complete URL with query parameters
                    string apiUrl = baseUrl + "?q=" + zipcode;

                    // Set the required headers
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "YOUR_RAPIDAPI_KEY");
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com");

                    // Send a GET request to the weather API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content (assuming it's JSON)
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Process the JSON response and extract the data you need
                        string weatherData = ParseWeatherData(jsonContent);

                        return weatherData;
                    }
                    else
                    {
                        // Handle non-successful HTTP responses here
                        return "Error: Unable to retrieve weather data.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        // Define a class that matches the structure of the JSON response
        public class WeatherResponseModel
        {
            public CurrentModel current { get; set; }
        }

        public class CurrentModel
        {
            public string temp_c { get; set; }
            public ConditionModel condition { get; set; }
        }

        public class ConditionModel
        {
            public string text { get; set; }
        }

        // Implement a method to parse the JSON response and extract the weather data
        private string ParseWeatherData(string jsonContent)
        {
            try
            {
                // Deserialize the JSON response into a suitable model class
                var weatherData = JsonConvert.DeserializeObject<WeatherResponseModel>(jsonContent);

                if (weatherData != null && weatherData.current != null)
                {
                    // Extract the temperature and condition information
                    string temperature = weatherData.current.temp_c;
                    string conditions = weatherData.current.condition.text;

                    // Build the weather data string
                    string weatherInfo = $"Temperature: {temperature}°C, Conditions: {conditions}";

                    return weatherInfo;
                }
                else
                {
                    return "No weather data available.";
                }
            }
            catch (JsonException ex)
            {
                return $"Error parsing JSON: {ex.Message}";
            }
        }

        string IWeatherService.GetWeather(int zipcode)
        {
            throw new NotImplementedException();
        }
    }
}
