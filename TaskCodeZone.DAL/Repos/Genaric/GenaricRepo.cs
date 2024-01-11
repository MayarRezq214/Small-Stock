using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class GenaricRepo<TEntity> :IGenaricRepo<TEntity>
        where TEntity : class
    {
        private readonly StockContext _stockContext;
        public GenaricRepo(StockContext context)
        {
            _stockContext = context;
        }
        public void Add(TEntity entity)
        {
            _stockContext.Set<TEntity>().Add(entity);
        }

        public void DeleteById(int id)
        {
            TEntity? Entity = _stockContext.Set<TEntity>().Find(id);
            if (Entity != null) 
            {
                _stockContext.Set<TEntity>().Remove(Entity);
            }
        } 
        public List<TEntity> GetAll()
        {
            return _stockContext.Set<TEntity>().ToList();
        }
        public void Update(TEntity entity)
        {
            _stockContext.Set<TEntity>().Update(entity);
        }
        public TEntity GetById(int id)
        {
            return _stockContext.Set<TEntity>().Find(id)!;    
        }
    }
}
