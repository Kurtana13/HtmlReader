using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

//Saba Kurtanidze

namespace TestTaskFlatRockTech
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string htmlFileName = @"HtmlString.txt";
            string directory = Environment.CurrentDirectory;
            string filePath = Path.Combine(directory, htmlFileName);
            string htmlString;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                htmlString = streamReader.ReadToEnd();
            }

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            var items = htmlDoc.DocumentNode.SelectNodes("//div[@class='item']");

            List<Object> list = new List<Object>();
            foreach (var item in items)
            {
                string name = DecodeProductName.Decode(item.SelectSingleNode(".//a/img").Attributes["alt"].Value);
                string price = RemoveCurrency.Remove(item.SelectSingleNode(".//span[@class='price-display formatted']/span").InnerText);
                string rating = RatingNormalization.Normalize(item.Attributes["rating"].Value);

                list.Add(new
                {
                    productName = name,
                    price = price,
                    rating = rating
                });  
            }
            string jsonOutput = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(jsonOutput);
            Console.ReadLine();
        }
    }
}
