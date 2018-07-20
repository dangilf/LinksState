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
        public ActionResult CreateRequest()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewPersonalReports()
        {
            return View();
        }
        
        public ActionResult ViewReportResult()
        {
            return View();
        }
    }
}