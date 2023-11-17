using DataBase.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class ClientAuditorsRepository: GenericRepository<ClientAuditors>, IClientAuditorsRepository
    {
        public ClientAuditorsRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
