using DataBase.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class ClientAuditorsRepository : GenericRepository<ClientAuditors>, IClientAuditorsRepository
    {
        public ClientAuditorsRepository(ApplicationContext context) : base(context)
        {
            
        }
        //public async Task<ClientAuditors> GetClientAuditors(ClientAuditorsRepository clientAuditorsRepository)
        //{
        //    var output = await _context.AddAsync(auditorsDetails);
        //    return output.Entity;
        //}
    }

}
