using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Net;
using System.Linq;


namespace TrendingNewsService
{
    public class TrendingNewsService : ITrendingNewsService
    {
        public string apiUrl = "https://newsapi.org/v2/top-headlines?country=us&apiKey=3b80fd3976924629b83343fcae171cf9"; // Replace with the actual API URL


        public async Task<string> GetTrendingNews()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Make an HTTP GET request to the API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Return the API response as a string
                        return responseBody;
                    }
                    else
                    {
                        // Handle the API request failure
                        Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., network errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Return an empty string or handle the failure case as needed
            Console.WriteLine("API request failed.");
            return string.Empty;
        }


        public class NewsResponse
        {
            public string status { get; set; }
            public int totalResults { get; set; }
            public List<Article> articles { get; set; }
        }

        public class Article
        {
            public Source source { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string urlToImage { get; set; }
            public DateTime publishedAt { get; set; }
            public string content { get; set; }
        }

        public class Source
        {
            public object id { get; set; }
            public string name { get; set; }
        }

        public List<string> GetNews(string searchString)
        {
            string url = GoogleURLFormat(searchString);
            return FetchArticleLinks(url);
        }

        internal string GoogleURLFormat(string searchString)
        {
            string encodedSearchString = WebUtility.UrlEncode(searchString);

            // Construct the Google News URL with the encoded search string
            string googleNewsUrl = $"https://news.google.com/search?q={encodedSearchString}&hl=en-US&gl=US&ceid=US%3Aen";
            return googleNewsUrl;
        }

        internal List<string> FetchArticleLinks(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var articleNodes = doc.DocumentNode.SelectNodes("//a[starts-with(@href, './articles')]");

            List<string> fullLinks = new List<string>();

            foreach (var node in articleNodes.Take(10))
            {
                string link = "https://news.google.com" + node.Attributes["href"].Value;
                fullLinks.Add(link);
            }

            return fullLinks;
        }
    }
}
