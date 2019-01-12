using Butterfly.Data;
using Butterfly.Models.Cores;
using Butterfly.Windows.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Repositories.Users
{
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        public UsersRepository(DataContext dataContext)
            :base(dataContext)
        {

        }
    }
}
