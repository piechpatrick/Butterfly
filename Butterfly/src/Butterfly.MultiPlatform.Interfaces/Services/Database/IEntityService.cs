using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Interfaces.Services.Database
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        TEntity Create(TEntity domain);
        TEntity Update(TEntity domain);
        TEntity Delete(TEntity domain);
        IEnumerable<TEntity> GetAll();
    }
}
