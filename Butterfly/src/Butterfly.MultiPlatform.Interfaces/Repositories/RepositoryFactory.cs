using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.MultiPlatform.Interfaces.Repositories
{
    public class RepositoryFactory<TRepo, TSource, TItem> : IRepositoryFactory<TRepo, TSource, TItem>
        where TRepo : IRepository<TItem>, new()
        where TSource : IRepository<TItem>, new()
        where TItem : class, new()
    {

        public RepositoryFactory()
        {

        }

        public TRepo Create(TSource repo)
        {
            var repository = new TRepo();
            repository.SetSource(repo);
            return repository;
        }
    }
}
