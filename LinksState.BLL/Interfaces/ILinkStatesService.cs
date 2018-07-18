using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Interfaces
{
    public interface ILinkStatesService:IBaseService<LinkState, LinkStateDTO>
    {
        CheckRequestDTO GetParentRequest(int linkStateId);
        IEnumerable<LinkStateDTO> GetByRequestId(int requestId);
        IEnumerable<LinkStateDTO> GetNewLinkStates(int checkRequestId, int lastLinkStateId);
    }
}
