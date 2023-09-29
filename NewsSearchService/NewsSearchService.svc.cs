using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsSearchService
{
    public class NewsSearchService : INewsSearchService
    {
        public string GetNews(string searchString)
        {
            string url = GoogleURLFormat(searchString);
            return url;
        }

        internal string GoogleURLFormat(string searchString)
        {
            string encodedSearchString = WebUtility.UrlEncode(searchString);

            // Construct the Google News URL with the encoded search string
            string googleNewsUrl = $"https://news.google.com/search?q={encodedSearchString}&hl=en-US&gl=US&ceid=US%3Aen";
            return googleNewsUrl;
        }
    }
}
