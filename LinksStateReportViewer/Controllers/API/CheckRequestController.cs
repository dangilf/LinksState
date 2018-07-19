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
using Microsoft.AspNet.Identity;

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

        [HttpGet]
        [Route("personal/{mail}/")]
        public IEnumerable<CheckRequestDTO> GetPersonalRequests(string mail)
        {
            return _checkRequestService.GetPersonalRequests(mail);
        }
        [HttpPost]
        [Route("uploadCsv/{mail}/")]
        public async void UploadCsv(string mail)
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer =await file.ReadAsByteArrayAsync();               
                
                _checkRequestService.AddRequestsFromCsv(buffer, mail);
            }
        }
    }
}
