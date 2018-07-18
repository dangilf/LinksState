using AutoMapper;
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
    public abstract class BaseCRUDService<TEntity, TDTO> where TEntity : BaseEntity where TDTO : BaseDTO
    {
        internal IUnitOfWork uof { get; set; }
        public BaseCRUDService(IUnitOfWork unitOfWork)
        {
            uof = unitOfWork;
        }

        public IEnumerable<TDTO> GetAll()
        {
            var entities = uof.Repository<TEntity>().GetAll();
            var entitiesDTO = Mapper.Map<IEnumerable<TDTO>>(entities);
            return entitiesDTO;
        }

        public TDTO GetById(int id)
        {
            var entity = uof.Repository<TEntity>().GetById(id);
            var entityDTO = Mapper.Map<TDTO>(entity);
            return entityDTO;
        }

        public void Create(TDTO entityDTO)
        {
            var entity = Mapper.Map<TEntity>(entityDTO);
            uof.Repository<TEntity>().Create(entity);
            uof.Save();
        }

        public void Delete(TDTO entityDTO)
        {
            uof.Repository<TEntity>().Remove(entityDTO.ID);
            uof.Save();
        }

        public void Delete(int id)
        {
            uof.Repository<TEntity>().Remove(id);
            uof.Save();
        }
        public void Update(TDTO entityTDTO)
        {
            var entity = uof.Repository<TEntity>().GetById(entityTDTO.ID);
            if (entity != null)
            {
                Mapper.Map(entityTDTO, entity);
                uof.Repository<TEntity>().Update(entity);
                uof.Save();
            }
        }
    }
}
