using LinksState.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Services
{
    public class CsvParser : ICsvParser
    {
        public IEnumerable<IEnumerable<string>> GetContent(byte[] csv)
        {
            var str = System.Text.Encoding.Default.GetString(csv);
            var lines = str.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            List<List<string>> rows = new List<List<string>>();
            foreach(var line in lines)
            {
                var values = line.Split(';').ToList();
                rows.Add(values);
            }
            return rows;
        }
    }
}
