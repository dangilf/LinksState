using LinksState.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinksState.BLL.Services
{
    public class HtmlParser : IHtmlParser
    {
        public List<string> GetLinksFromHtml(string baseUrl, string htmlString)
        {
            List<string> links = new List<string>();
            string pattern = "(?:href|src)=[\"|']?(.*?)[\"|'|>]+";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(htmlString);
            foreach (Match match in matches)
            {
                string link = RemoveUnnecessary(match.Value);
                link = new Uri(new Uri(baseUrl), link).ToString();
                links.Add(link);
            }
            return links;
        }

        private string RemoveUnnecessary(string str)
        {
            int index = 0;
            str = str.Replace("src=\"", String.Empty)
                .Replace("href=\"", String.Empty)
                .Replace("src='", String.Empty)
                .Replace("href='", String.Empty)
                .Replace("SRC=\"", String.Empty)
                .Replace("HREF=\"", String.Empty)
                .Replace("SRC='", String.Empty)
                .Replace("HREF='", String.Empty);

            index = str.IndexOf("\"");
            if (index <= 0)
                index = str.IndexOf("'");
            if (index < 0)
                index = 0;
            str = str.Remove(index, str.Length - index);
            return str;
        }
    }
}
