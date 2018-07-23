using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Util
{
    public static class Config
    {
        public static string Server {
            get
            {
                return ConfigurationManager.AppSettings["Server"];
            }
        }
        public static int Port
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            }
        }
        public static string ErrorTo
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorTo"];
            }
        }
        public static string From
        {
            get
            {
                return ConfigurationManager.AppSettings["From"];
            }
        }
    }
}
