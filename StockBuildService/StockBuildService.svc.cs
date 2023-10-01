using System;
using System.Threading;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Web.Script.Serialization;

namespace StockBuildService
{
    public class StockBuildService : IStockBuildService
    {
        private static readonly string FILE_PATH;
        private static readonly string ALPHA_VANTAGE_API_KEY = "Y9XC1LE7IL6AHFSXV";

        static StockBuildService()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo projectDirectoryInfo = Directory.GetParent(currentDirectory);
            DirectoryInfo solutionDirectoryInfo = Directory.GetParent(projectDirectoryInfo.FullName);
            FILE_PATH = Path.Combine(solutionDirectoryInfo.FullName, "stockBuild.txt");
        }

        public string StockBuild(string symbol)
        {
            string[] top100Stocks = new string[] { "AAPL", "MSFT", "GOOGL", "AMZN", "NVDA", "TSLA", "META", "LLY", "V", "XOM", "UNH", "WMT", "JPM", "JNJ", "MA", "PG", "AVGO", "CVX", "HD", "ORCL", "ABBV", "MRK", "COST", "KO", "PEP", "ADBE", "CSCO", "BAC", "CRM", "TMO", "MCD", "PFE", "DHR", "CMCSA", "ABT", "NFLX", "AMD", "TMUS", "WFC", "INTC", "DIS", "NKE", "TXN", "COP", "AMGN", "PM", "INTU", "CAT", "VZ", "MS", "UPS", "IBM", "UNP", "QCOM", "HON", "BMY", "GE", "LOW", "SPGI", "NEE", "AMAT", "BA", "NOW", "BKNG", "AXP", "DE", "T", "GS", "RTX", "SBUX", "SYK", "PLD", "LMT", "ISRG", "EHC", "TJX", "SCHW", "ADP", "BLK", "MDLZ", "MMC", "UBER", "GILD", "CVS", "VRTX", "REGN", "ABNB", "ADI", "CI", "LRCX", "SLB", "PGR", "ZTS", "C", "BX", "BSX", "AMT", "BDX", "MO" }; // Populate this array with the top 100 stock symbols

            using (StreamWriter writer = new StreamWriter(FILE_PATH, append: true))
            {
                foreach (string stockSymbol in top100Stocks)
                {
                    float stockPrice = FetchStockPrice(stockSymbol);
                    writer.WriteLine($"{stockSymbol}|{stockPrice}");
                   
                }
            }
            Console.WriteLine(FILE_PATH);
            return FILE_PATH;
        }

        private float FetchStockPrice(string symbol)
        {
            string url = $"https://www.marketwatch.com/investing/stock/{symbol.ToLower()}";

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var firstElementWithClassValue = doc.DocumentNode.SelectSingleNode("//*[contains(@class, 'value')]");

            if (firstElementWithClassValue != null)
            {
                return float.Parse(firstElementWithClassValue.InnerText.Trim());
            }
            else
            {
                throw new Exception($"Failed to fetch price for stock symbol: {symbol}");
            }
        }
    }
}
