using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.DAL.Models
{
    public class CheckRequest: BaseEntity
    {
        public string UserName { get; set; }
        public string BaseUrl { get; set; }
        public int NestingLevel { get; set; }
        public virtual List<LinkState> LinkStates { get; set; }
    }
}
