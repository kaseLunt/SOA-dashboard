using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WordCountService;

namespace WordCountTryItPage
{
    public partial class WordCountTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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