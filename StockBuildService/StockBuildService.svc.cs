using System;
using System.IO;

namespace StockBuildService
{
    public class StockBuildService : IStockBuildService
    {
        private static readonly string FILE_PATH;

        static StockBuildService()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo projectDirectoryInfo = Directory.GetParent(currentDirectory); // Gets the StockBuildService directory
            DirectoryInfo solutionDirectoryInfo = Directory.GetParent(projectDirectoryInfo.FullName); // Gets the Project3 directory
            FILE_PATH = Path.Combine(solutionDirectoryInfo.FullName, "sharedData.txt");
        }

        public string StockBuild(string symbol)
        {
            // Dummy value for the stock price
            float stockPrice = 120.3f;

            // Save the symbol-price pair to the file
            using (StreamWriter writer = new StreamWriter(FILE_PATH, append: true))
            {
                writer.WriteLine($"{symbol}|{stockPrice}");
            }
            return FILE_PATH;
        }
    }
}