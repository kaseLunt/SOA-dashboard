using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryItPage.WeatherServiceReference;
using TryItPage.NewsServiceReference;

namespace TryItPage
{
    public partial class TryThePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            TryItPage.NewsServiceReference.NewsSearchServiceClient client = new NewsServiceReference.NewsSearchServiceClient();
            var urls = client.GetNews(keywords);

            // Display the greeting message in the result textbox
            string[] stringArray = urls;

            // Use a for loop to iterate through the array
            TextBox2.Text = string.Join("\n\n", stringArray);
        }
    }
}