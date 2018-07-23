using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LinksState.BLL.Util
{
    class MailSender
    {
        private static MailSender instance;

        private static SmtpClient client;

        private static object syncRoot = new Object();

        protected MailSender(string server, int port)
        {
            client = new SmtpClient
            {
                Port = port,
                Host = server,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }

        public static MailSender GetInstance(string server, int port)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new MailSender(server, port);
                    }
                }
            }
            return instance;
        }
        
        public static void SendErrorMessage(string body)
        {
            MailMessage mail = new MailMessage(Config.From, Config.ErrorTo);
            mail.Body = body;
            mail.Subject = "An error occured in Links State App";
            client.Send(mail);
        } 
    }
}
