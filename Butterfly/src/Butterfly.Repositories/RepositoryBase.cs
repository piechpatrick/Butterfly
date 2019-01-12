using Butterfly.Data;
using Butterfly.Interfaces.Repositories;
using Butterfly.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DataContext DataContext;

        public RepositoryBase(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public TEntity Get(int id)
        {
            return this.DataContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DataContext.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.DataContext.Set<TEntity>().ToList();
        }
        public TEntity Add(TEntity entity)
        {
            return this.DataContext.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return this.DataContext.Set<TEntity>().AddRange(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            return this.DataContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            return this.DataContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
