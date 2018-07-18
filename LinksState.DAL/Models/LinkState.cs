using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.DAL.Models
{
    public class LinkState : BaseEntity
    {
        public virtual CheckRequest CheckRequest {get;set;}
        public string URL { get; set; }
        public int StatusCode { get; set; }
    }
}
