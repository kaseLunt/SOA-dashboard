using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryItPage.WeatherServiceReference;
using TrendingNewsService;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using TryItPage.TrendingNewsServiceReference;

namespace TryItPage
{
    public partial class TryThePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnSubmit_Click3(object sender, EventArgs e)
        {
            try
            {
                TrendingNewsServiceClient client = new TrendingNewsServiceClient();
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
                    lblMessage.Text = "No data received from the service.";
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                lblMessage.Text = "An error occurred: " + ex.Message;
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the user's name from the input textbox
            string inputString = txtName.Text;
            int zipcode = int.Parse(inputString);

            // Create a greeting message
            WeatherServiceReference.WeatherServiceClient client = new WeatherServiceReference.WeatherServiceClient();
            var weatherData = client.GetWeather(zipcode);

            // Display the greeting message in the result textbox
            txtResult.Text = weatherData;
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            // Get the user's name from the input textbox
            string keywords = TextBox1.Text;

            // Create a greeting message
            TrendingNewsServiceClient client = new TrendingNewsServiceClient();
            var urls = client.GetNews(keywords);

            // Display the greeting message in the result textbox
            string[] stringArray = urls;

            // Use a for loop to iterate through the array
            TextBox2.Text = string.Join("\n\n", stringArray);
        }

        protected void btnSubmit_Click2(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                // Read the content of the uploaded file into a string
                using (StreamReader reader = new StreamReader(fileUpload.PostedFile.InputStream))
                {
                    // Initialize a StringBuilder to store all words
                    StringBuilder allWords = new StringBuilder();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            // Split the line into words
                            string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            // Append the words to the StringBuilder
                            foreach (string word in words)
                            {
                                allWords.Append(word);
                                allWords.Append(" "); // Add a space between words
                            }
                        }
                    }

                    // Now, you can use the 'allWords' variable to work with all the words in the uploaded file
                    string allWordsText = allWords.ToString();
                    WordCountServiceReference.Service1Client client = new WordCountServiceReference.Service1Client();
                    string jsonResult = client.GetData(allWordsText);
                    //Response.Write(allWordsText);
                    //Response.Write(jsonResult);
                    txtDisplay.Text = jsonResult;
                }
            }
            else
            {
                Response.Write("No file selected.");
            }
        }
    }
}
