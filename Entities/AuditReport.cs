using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AuditReport
    {
        public int Id { get; set; }
        public string AuditType { get; set; }
        public string ClientName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string AuditOutcome { get; set; }
        public string OwerName { get; set; }
        public List<string> AuditorList { get; set; }
    }
}
