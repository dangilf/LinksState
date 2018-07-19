using AutoMapper;
using LinksState.BLL.Interfaces;
using LinksState.BLL.Models;
using LinksState.DAL.EF;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Services
{
    public class CheckRequestsService : BaseCRUDService<CheckRequest, CheckRequestDTO>, ICheckRequestService
    {
        IHtmlParser _pageParser;
        IWebHelper _webHelper;
        public CheckRequestsService(IUnitOfWork unitOfWork, IHtmlParser pageParser, IWebHelper webHelper) : base(unitOfWork)
        {
            _pageParser = pageParser;
            _webHelper = webHelper;
        }

        public IEnumerable<LinkStateDTO> GetAllLinkStates(int checkRequestId)
        {
            var entities = uof.Repository<CheckRequest>().GetById(checkRequestId).LinkStates;
            var entitiesDTO = Mapper.Map<IEnumerable<LinkStateDTO>>(entities);
            return entitiesDTO;
        }

        public IEnumerable<CheckRequestDTO> GetPersonalRequests(string mail)
        {
            var entities = uof.Repository<CheckRequest>().Get(r => r.UserName.Equals(mail, StringComparison.InvariantCultureIgnoreCase));
            var entitiesDTO = Mapper.Map<IEnumerable<CheckRequestDTO>>(entities);
            return entitiesDTO;
        }

        public async void StartCheckingLinks(int checkRequestId)
        {
            var request = uof.Repository<CheckRequest>().GetById(checkRequestId);
            if (request == null || request.NestingLevel == 0)
                return;
            await Task.Run(() => ProcessRequest(request, request.BaseUrl, request.NestingLevel));
        }

        #region Private Methods
        private void ProcessRequest(CheckRequest request, string url, int nestingLevel)
        {   

            var statusCode = _webHelper.GetStatusCode(url);

            LinkState state = new LinkState()
            {
                CheckRequest = request,
                StatusCode = statusCode,
                URL = url
            };
            uof.Repository<LinkState>().Create(state);
            uof.Save();

            if (nestingLevel > 0 )
            { 
                var html = _webHelper.GetHtmlCodeByLink(url);
                var links = _pageParser.GetLinksFromHtml(url, html);
                foreach (var link in links)
                {                    
                    ProcessRequest(request, link, nestingLevel - 1);
                }
            }
        }
        #endregion
    }
}
