using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AuditStatus
    {
        public int Id { get; set; }
        public string AuditName { get; set; }
        public bool IsActive { get; set; }
    }
}
