using LinksState.BLL.Interfaces;
using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LinksStateReportViewer.Controllers.API
{
    
    public abstract class BaseApiController<TEntity, TDTO> : ApiController where TEntity : BaseEntity where TDTO : BaseDTO
    {
        internal IBaseService<TEntity, TDTO> baseService;


        public BaseApiController(IBaseService<TEntity, TDTO> svc)
        {
            baseService = svc;
        }
        
        [HttpGet]
        [Route("")]
        public IEnumerable<TDTO> GetAll()
        {
            return baseService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public TDTO Get(int id)
        {
            return baseService.GetById(id);
        }

        [HttpPost]
        [Route("")]
        public int Create([FromBody]TDTO model)
        {
            return baseService.Create(model);
        }

        [HttpPut]
        [Route("")]
        public void Update([FromBody]TDTO model)
        {
            baseService.Update(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            baseService.Delete(id);
        }
    }
}
