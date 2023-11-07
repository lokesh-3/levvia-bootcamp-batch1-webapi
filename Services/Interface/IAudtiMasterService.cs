using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAudtiMasterService
    {
        public Task<List<AuditMasterDTO>> GetAuditMaster();
    }
}
