using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;
using TrendingNewsService;
using TrendingNewsServiceReference;

namespace NewsApp
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TrendingNewsTryItPage.TrendingNewsServiceRef.TrendingNewsServiceClient client = new TrendingNewsTryItPage.TrendingNewsServiceRef.TrendingNewsServiceClient();
                //TrendingNewsTryItPage.TrendingNewsServiceRef.TrendingNewsServiceClient client = new TrendingNewsServiceClient();


                string jsonData = client.GetTrendingNews();

                if (!string.IsNullOrEmpty(jsonData))
                {
                    // Deserialize JSON to C# object
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    RootObject data = serializer.Deserialize<RootObject>(jsonData);

                    if (data != null && data.articles != null)
                    {
                        // Bind the data to the GridView
                        gvNews.DataSource = data.articles;
                        gvNews.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "No News Available";
                    }
                }
                else
                {
                    lblMessage.Text = "Failed to fetch news data.";
                }
            }
        }


        public class RootObject
        {
            public string status { get; set; }
            public int totalResults { get; set; }
            public List<Article> articles { get; set; }
        }

        public class Source
        {
            public object id { get; set; }
            public string name { get; set; }
        }

        public class Article
        {
            public Source source { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string urlToImage { get; set; }
            public string publishedAt { get; set; }
            public string content { get; set; }
        }
    }
}
