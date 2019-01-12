using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butterfly.Data;
using Butterfly.Repositories.Users;
using Butterfly.Windows.Data;

namespace Butterfly.Services.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            this.Users = new UsersRepository(_dataContext);
        }
        public IUsersRepository Users { get; private set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Complete();
            _dataContext.Dispose();
        }
    }
}
