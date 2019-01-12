using Butterfly.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Services.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }

        int Complete();
    }
}
