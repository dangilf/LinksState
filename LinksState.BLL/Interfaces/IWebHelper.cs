using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Interfaces
{
    public interface IWebHelper
    {
        string GetHtmlCodeByLink(string link);
        int GetStatusCode(string url);
    }
}
