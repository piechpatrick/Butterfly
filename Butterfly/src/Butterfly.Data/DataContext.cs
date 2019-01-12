using Butterfly.Models.Cores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base(ConnectionString)
        {

        }

        public static string ConnectionString = "Data Source=DESKTOP-PL9BGF5;Initial Catalog=Butterfly;Integrated Security=True";

        public virtual DbSet<User> Users { get; set; }
    }
}
