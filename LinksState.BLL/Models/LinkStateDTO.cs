using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Models
{
    public class LinkStateDTO:BaseDTO
    {
        public string URL { get; set; }
        public int StatusCode { get; set; }
    }
}
