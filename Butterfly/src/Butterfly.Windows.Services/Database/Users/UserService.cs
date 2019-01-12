using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Butterfly.Models.Cores;

namespace Butterfly.Services.Database.Users
{
    public class UserService : EntityService, IUserService
    {
        public UserService()
            :base()
        {
            
        }
        public User Create(User domain)
        {
            using (base.UnitOfWork)
            {
                return base.UnitOfWork.Users.Add(domain);
            }
        }

        public User Delete(User domain)
        {
            using (base.UnitOfWork)
            {
                return base.UnitOfWork.Users.Remove(domain);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (base.UnitOfWork)
            {
                return base.UnitOfWork.Users.GetAll();
            }
        }

        public User Update(User domain)
        {
            using (base.UnitOfWork)
            {
                return base.UnitOfWork.Users.Add(domain);
            }
        }
    }
}
