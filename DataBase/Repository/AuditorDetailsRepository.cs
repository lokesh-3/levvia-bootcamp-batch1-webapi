using DataBase.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class AuditorDetailsRepository: GenericRepository<AuditorsDetails>, IAuditorDetailsRepository
    {
        public AuditorDetailsRepository(ApplicationContext context) : base(context)
        {
                
        }

        
        public async Task<AuditorsDetails> AddAuditorsDetails(AuditorsDetails auditorsDetails)
        {
            var output = await _context.AddAsync(auditorsDetails);
            return output.Entity;
        }
    }
}
