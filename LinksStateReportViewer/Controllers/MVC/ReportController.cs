using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinksStateReportViewer.Controllers.MVC
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult CreateReport()
        {
            return View();
        }
    }
}