using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Interfaces
{
    public interface ICheckRequestService: IBaseService<CheckRequest, CheckRequestDTO>
    {
        IEnumerable<LinkStateDTO> GetAllLinkStates(int checkRequestId);        
        void StartCheckingLinks(int checkRequestId);
        IEnumerable<CheckRequestDTO> GetPersonalRequests(string mail);

    }
}
