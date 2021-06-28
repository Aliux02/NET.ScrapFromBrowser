using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace NET.ScrapFromBrowser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://www.cvonline.lt/lt/search?limit=20&offset=0&categories%5B0%5D=INFORMATION_TECHNOLOGY&towns%5B0%5D=540&isHourlySalary=false&isRemoteWork=false";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes("//span[contains(@class, 'jsx-1471379408 vacancy-item__title')]");

            var professionNames = nodes.Where(node => node.InnerText.Contains("CONSULTANT"));

            foreach (HtmlNode item in professionNames)
            {
                Console.WriteLine(item.InnerText);
            }
        }
    }
}
