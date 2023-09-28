using Client.StockBuildServiceRef;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Specify the stock symbol for testing
            string stockSymbol = "AAPL"; // Change this to the symbol you want to test

            // Invoke the StockBuild operation
            StockBuildServiceClient buildClient = new StockBuildServiceClient();
            string filePath = buildClient.StockBuild(stockSymbol);

            // Check if the file exists
            if (File.Exists(filePath))
            {
                Console.WriteLine("File created successfully.");

                // Read and display the file content
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File creation failed.");
            }
        }
    }
}
