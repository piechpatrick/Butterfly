using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Butterfly.Models.Cores
{
    public class EntityBase 
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool Deleted { get; set; }

        public EntityBase()

        {
            Created = DateTime.Now;
            Deleted = false;

        }

        public virtual int IdentityID()

        {

            return 0;

        }

        public virtual object[] IdentityID(bool dummy = true)

        {

            return new List<object>().ToArray();

        }

    }
}
