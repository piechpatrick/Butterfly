using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.Models.Cores
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
