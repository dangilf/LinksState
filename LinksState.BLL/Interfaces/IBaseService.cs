using LinksState.BLL.Models;
using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Interfaces
{
    public interface IBaseService<TEntity, TDTO> where TEntity : BaseEntity where TDTO : BaseDTO
    {
        IEnumerable<TDTO> GetAll();
        TDTO GetById(int id);
        void Create(TDTO entity);
        void Delete(TDTO entity);
        void Delete(int id);
        void Update(TDTO entity);
    }
}
