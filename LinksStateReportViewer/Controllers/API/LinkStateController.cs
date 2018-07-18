using LinksState.BLL.Interfaces;
using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinksStateReportViewer.Controllers.API
{
    [RoutePrefix("linkstates")]
    public class LinkStateController : BaseApiController<LinkState, LinkStateDTO>
    {
        ILinkStatesService _linkStatesService;
        public LinkStateController(ILinkStatesService linkStatesService) : base(linkStatesService)
        {
            _linkStatesService = linkStatesService;
        }


        [HttpGet]
        [Route("{checkRequestId}/linkStates")]
        public IEnumerable<LinkStateDTO> GetAllByRequestId(int checkRequestId)
        {
            return _linkStatesService.GetByRequestId(checkRequestId);
        }

        [Route("{checkRequestId}/newLinkStates/{lastId}")]
        public IEnumerable<LinkStateDTO> GetNewByRequestId(int checkRequestId, int lastId)
        {
            return _linkStatesService.GetNewLinkStates(checkRequestId,lastId);
        }
    }
}
