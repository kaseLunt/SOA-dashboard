using System;
using System.IO;

namespace StockQuoteService
{
    /// <summary>
    /// Provides functionality to retrieve stock prices based on stock symbols.
    /// </summary>
    public class StockQuoteService : IStockQuoteService
    {
        // Path to the shared file containing stock symbols and their respective prices.
        private static readonly string FILE_PATH;

        /// <summary>
        /// Static constructor to initialize the FILE_PATH.
        /// Determines the path to the shared data file 'sharedData.txt' located in the 'Project3' directory.
        /// </summary>
        static StockQuoteService()
        {
            // Get the base directory of the currently executing application.
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Ascend to the StockQuoteService directory.
            DirectoryInfo projectDirectoryInfo = Directory.GetParent(currentDirectory);

            // Ascend to the Project3 (solution) directory.
            DirectoryInfo solutionDirectoryInfo = Directory.GetParent(projectDirectoryInfo.FullName);

            // Combine the solution directory path with the filename to get the full path to the shared file.
            FILE_PATH = Path.Combine(solutionDirectoryInfo.FullName, "sharedData.txt");
        }

        /// <summary>
        /// Retrieves the price of a given stock symbol.
        /// </summary>
        /// <param name="stock">The stock symbol for which the price needs to be fetched.</param>
        /// <returns>A string indicating the price of the input stock symbol.</returns>
        public string StockQuote(string stock)
        {
            // Default price message if the stock symbol is not found in the file.
            string stockPrice = "Not Found";

            // Check if the shared data file exists.
            if (File.Exists(FILE_PATH))
            {
                // Read all lines from the shared data file.
                string[] stockData = File.ReadAllLines(FILE_PATH);

                // Iterate over each line in the data.
                foreach (string line in stockData)
                {
                    // Split the line into symbol and price parts using the delimiter '|'.
                    string[] parts = line.Split('|');

                    // Check if the current line's symbol matches the input stock symbol.
                    if (parts.Length == 2 && parts[0].Equals(stock, StringComparison.OrdinalIgnoreCase))
                    {
                        // Assign the matched stock's price to the stockPrice variable.
                        stockPrice = parts[1];
                        break;
                    }
                }
            }

            // Return the stock price message.
            return $"Price of {stock.ToUpper()}: {stockPrice}";
        }
    }
}
