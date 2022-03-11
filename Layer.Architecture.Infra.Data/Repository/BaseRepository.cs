using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly RaCaGakContext _raCaGaKContext;

        public BaseRepository(RaCaGakContext raCaGakContext)
        {
            _raCaGaKContext = raCaGakContext;
        }

        public void Insert(TEntity obj)
        {
            _raCaGaKContext.Set<TEntity>().Add(obj);
            _raCaGaKContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _raCaGaKContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _raCaGaKContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _raCaGaKContext.Set<TEntity>().Remove(Select(id));
            _raCaGaKContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _raCaGaKContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _raCaGaKContext.Set<TEntity>().Find(id);

    }
}
