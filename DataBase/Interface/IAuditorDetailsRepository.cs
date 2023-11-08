using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    public interface IAuditorDetailsRepository: IGenericRepository<AuditorsDetails>
    {

        public Task<AuditorsDetails> AddAuditorsDetails(AuditorsDetails  auditorsDetails);
    
    }
}
