using LinksState.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Remove(int id);
        void Update(TEntity item);
    }
}
