using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public interface IGenaricRepo<TEntity>
    where TEntity : class
    {
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void DeleteById(int id);
        public void Update(TEntity entity);
        public TEntity GetById(int id);
    }
}
