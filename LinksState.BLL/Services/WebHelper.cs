﻿using LinksState.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Services
{
    public class WebHelper : IWebHelper
    {
        WebClient client = new WebClient();
        public WebHelper()
        {
            client.Credentials = new NetworkCredential("gilfanovd", "61Ubkmafyjd", "russia");
        }

        public string GetHtmlCodeByLink(string link)
        {
            client.UseDefaultCredentials = true;
            string htmlCode = string.Empty;
            try
            {
                htmlCode = client.DownloadString(link);
            }
            catch (Exception ex)
            {
                //TODO
            }
            return htmlCode;
        }

        public int GetStatusCode(string url)
        {
            int statusCode = -1;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                statusCode = (int)response.StatusCode;
                response.Close();

            }
            catch (WebException e)
            {
                if (e.Response != null)
                {
                    statusCode = (int)((HttpWebResponse)e.Response).StatusCode;
                }
            }
            catch (Exception ex)
            {
                //TODO
            }
            return statusCode;
        }
    }
}
