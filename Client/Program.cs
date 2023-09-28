using Client.StockBuildServiceRef;
using Client.StockQuoteServiceRef;
using Client.WeatherServiceRef;
using System;
using System.IO;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

                // Now invoke the StockQuote operation to fetch the stock price
                StockQuoteServiceClient quoteClient = new StockQuoteServiceClient();
                string stockPrice = quoteClient.StockQuote(stockSymbol);

                Console.WriteLine($"Stock Price for {stockSymbol}: {stockPrice}");
            }
            else
            {
                Console.WriteLine("File creation failed or the service couldn't read the stock price.");
            }

            // Invoke GetWeather operation 
            WeatherServiceClient weatherClient = new WeatherServiceClient();
            Console.WriteLine(weatherClient.GetWeather(85282));

            Console.ReadKey();
        }
    }
}
