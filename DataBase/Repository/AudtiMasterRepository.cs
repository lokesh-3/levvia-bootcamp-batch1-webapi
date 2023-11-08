using DataBase.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class AudtiMasterRepository : GenericRepository<AuditMaster>, IAudtiMasterRepository
    {
        public AudtiMasterRepository(ApplicationContext context) : base(context)
        {
            
        }

    }
}
