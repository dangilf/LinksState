using LinksState.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Util
{
    public static class Logger
    {
        
        public static void LogError(Exception ex, string prefix)
        {
            var message = prefix + Environment.NewLine +
                ex.Message + Environment.NewLine + ex.StackTrace;
            MailSender.SendErrorMessage(message);
        }
    }
}
