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
    public class LinkStatesService: BaseCRUDService<LinkState, LinkStateDTO>, ILinkStatesService
    {
        public LinkStatesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<LinkStateDTO> GetByRequestId(int requestId)
        {
            var entities = uof.Repository<LinkState>().Get(s => s.CheckRequest.ID == requestId);
            var entitiesDTO = Mapper.Map<IEnumerable<LinkStateDTO>>(entities);
            return entitiesDTO;
        }

        public CheckRequestDTO GetParentRequest(int linkStateId)
        {
            var entity = uof.Repository<LinkState>().GetById(linkStateId).CheckRequest;
            var entityDTO = Mapper.Map<CheckRequestDTO>(entity);
            return entityDTO;
        }
    }
}
