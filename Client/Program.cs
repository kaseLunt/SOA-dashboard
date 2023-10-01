using Client.StockBuildServiceRef;
using Client.StockQuoteServiceRef;
using Client.WeatherServiceRef;
using Client.NewsSearchServiceRef;
using System;
using System.IO;
using System.Net;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test NewsSearchService
            Console.Write("Enter a search term for news: ");
            string searchString = Console.ReadLine();
            NewsSearchServiceClient newsClient = new NewsSearchServiceClient();

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



            // Prompt the user for a stock symbol
            Console.Write("Enter the stock symbol: ");
            string stockSymbol = Console.ReadLine();

            // Invoke the StockBuild operation to store dummy stock price
            StockBuildServiceClient buildClient = new StockBuildServiceClient();
            string filePath = buildClient.StockBuild(stockSymbol);

            // Check if the file was created successfully
            if (File.Exists(filePath))
            {
                Console.WriteLine("File created successfully.");
                Console.WriteLine(filePath);

                // Now invoke the StockQuote operation to fetch the stock price
                StockQuoteServiceClient quoteClient = new StockQuoteServiceClient();
                string stockPrice = quoteClient.StockQuote(stockSymbol);

                Console.WriteLine($"Stock Price for {stockSymbol}: {stockPrice}");
            }
            else
            {
                Console.WriteLine("File creation failed or the service couldn't read the stock price.");
            }

            // Test WeatherService 
            WeatherServiceClient weatherClient = new WeatherServiceClient();
            Console.WriteLine(weatherClient.GetWeather(85282));

           
            



            
        }
    }
}
