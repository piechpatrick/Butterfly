using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Repositories
{
    public interface IRepositoryFactory<TRepo, TSource, TItem>
        where TRepo : IRepository<TItem>
        where TSource : IRepository<TItem>
        where TItem : class
    {
        TRepo Create(TSource repo);
    }
}
