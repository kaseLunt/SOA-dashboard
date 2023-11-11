
using Client.WeatherServiceRef;
using System;
using System.IO;
using System.Net;
using TryItPage.TrendingNewsServiceReference;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test NewsSearchService
            Console.Write("Enter a search term for news: ");
            string searchString = Console.ReadLine();
            TrendingNewsServiceClient newsClient = new TrendingNewsServiceClient();

            var newsLinks = newsClient.GetNews(searchString);
            if (newsLinks != null && newsLinks.Length > 0)
            {
                Console.WriteLine("Fetched News Links:");
                foreach (var link in newsLinks)
                {
                    Console.WriteLine(link);
                }
            }
            else
            {
                Console.WriteLine("No links found for the given search term.");
            }

            // Test WeatherService 
            WeatherServiceClient weatherClient = new WeatherServiceClient();
            Console.WriteLine(weatherClient.GetWeather(85282));

           
            



            
        }
    }
}
