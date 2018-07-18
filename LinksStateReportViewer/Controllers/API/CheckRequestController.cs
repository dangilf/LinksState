using LinksState.BLL.Interfaces;
using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LinksStateReportViewer.Controllers.API
{
    [RoutePrefix("checkRequest")]
    public class CheckRequestController : BaseApiController<CheckRequest, CheckRequestDTO>
    {
        ICheckRequestService _checkRequestService;
        public CheckRequestController(ICheckRequestService checkRequestService):base(checkRequestService)
        {
            _checkRequestService = checkRequestService;
        }

        [HttpPost]
        [Route("{checkRequestId}/start")]
        public void StartChecking(int checkrequestId)
        {
            _checkRequestService.StartCheckingLinks(checkrequestId);
        }

    }
}
