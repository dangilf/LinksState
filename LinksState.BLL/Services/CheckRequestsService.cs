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
        public CheckRequestsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<LinkStateDTO> GetAllLinkStates(int checkRequestId)
        {
            var entities = uof.Repository<CheckRequest>().GetById(checkRequestId).LinkStates;
            var entitiesDTO = Mapper.Map<IEnumerable<LinkStateDTO>>(entities);
            return entitiesDTO;
        }

        public async void StartCheckingLinks(int checkRequestId)
        {
            var request = uof.Repository<CheckRequest>().GetById(checkRequestId);
            if (request == null)
                return;
            await Task.Run(() => ProcessRequest(request));
        }

        #region Private Methods
        private void ProcessRequest(CheckRequest request)
        {
            //TODO
        }
        #endregion
    }
}
