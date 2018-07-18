using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Models
{
    public class CheckRequestDTO:BaseDTO
    {
        public string UserName { get; set; }
        public string BaseUrl { get; set; }
        public int NestingLevel { get; set; }
    }
}
