using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsSearchService
{
    public class NewsSearchService : INewsSearchService
    {
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
