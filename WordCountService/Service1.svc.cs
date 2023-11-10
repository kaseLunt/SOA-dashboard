using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace WordCountService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string filePath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            try
            {
                // Split the content of the filePath string by spaces
                 string[] words = filePath.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }
                }

                // Create a new dictionary to store the word count data in the desired format
                Dictionary<string, int> wordCountData = new Dictionary<string, int>();
                foreach (var entry in wordCounts)
                {
                    wordCountData[entry.Key] = entry.Value;
                }

                // Serialize the word count data as JSON
                string jsonResult = JsonConvert.SerializeObject(wordCountData, Newtonsoft.Json.Formatting.Indented);

                return jsonResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

            public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
