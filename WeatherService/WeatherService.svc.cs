using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
                    string baseUrl = "https://weatherapi-com.p.rapidapi.com/";

                    // Set the zip code as a query parameter
                    string zipParameter = $"zip={zipcode}";

                    // Construct the complete URL with query parameters
                    string apiUrl = baseUrl + "?" + zipParameter;

                    // Set the required headers
                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "SIGN-UP-FOR-KEY");
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

        // Implement a method to parse the JSON response and extract the weather data
       private string ParseWeatherData(string jsonContent)
{
    try
    {
        // Deserialize the JSON response into a suitable model class
        var weatherData = JsonConvert.DeserializeObject<WeatherResponseModel>(jsonContent);

        // Assuming that the JSON structure includes a "forecast" property for the 5-day forecast
        // Replace "YourWeatherModel" with the actual class that matches the JSON structure
        // You should adjust the property names according to the actual JSON structure
        var forecast = weatherData?.forecast?.fiveDayForecast;

        if (forecast != null && forecast.Length > 0)
        {
            // Create a StringBuilder to build the weather data
            StringBuilder weatherStringBuilder = new StringBuilder();

            // Iterate through the 5-day forecast and extract the relevant information
            foreach (var dailyForecast in forecast)
            {
                // Access properties like date, temperature, conditions, etc.
                string date = dailyForecast.date;
                string temperature = dailyForecast.temperature;
                string conditions = dailyForecast.conditions;

                // Build the weather data for each day
                string dayWeather = $"Date: {date}, Temperature: {temperature}, Conditions: {conditions}";

                // Append to the StringBuilder
                weatherStringBuilder.AppendLine(dayWeather);
            }

            // Return the compiled weather data
            return weatherStringBuilder.ToString();
        }
        else
        {
            return "No forecast data available.";
        }
    }
    catch (JsonException ex)
    {
        return $"Error parsing JSON: {ex.Message}";
    }
}

    }
}


