using Butterfly.Interfaces.Services.Database;
using Butterfly.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Services.Database
{
    public abstract class EntityService
    {
        private IUnitOfWork unitOfWork;
        public EntityService()
        {

        }
        protected IUnitOfWork UnitOfWork
        {
            get
            {
                if(this.unitOfWork == null)
                {
                    this.unitOfWork = new UnitOfWork(new Data.DataContext());
                }
                return unitOfWork;
            }
        }
    }
}
